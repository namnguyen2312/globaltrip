using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Infra.Services.Identity;
using NBT.Core.Services.ApplicationServices.Security;
using PagedList;
using AutoMapper;
using NBT.Core.Domain.Identity;
using NBT.Web.Framework.Models.Security;
using NBT.Web.Framework.Core;
using System.Threading.Tasks;
using NBT.Web.Framework.Extensions;
using Microsoft.AspNet.Identity;
using NBT.Core.Common.Exceptions;

namespace NBT.Web.Api.Controllers.Identity
{
    [Authorize]
    [RoutePrefix("api/appUser")]
    public class AppUserController : BaseApiController
    {
        ApplicationUserManager _userManager;
        IAppGroupService _appGroupService;
        IAppRoleService _appRoleService;
        IAppUserService _appUserService;
        public AppUserController(IErrorService errorService,
            ApplicationUserManager userManager,
            IAppGroupService appGroupService,
            IAppRoleService appRoleService,
            IAppUserService appUserService) : base(errorService)
        {
            _userManager = userManager;
            _appGroupService = appGroupService;
            _appRoleService = appRoleService;
            _appUserService = appUserService;
        }

        [Route("GetListPaging")]
        [HttpGet]
        [Authorize(Roles = nameof(PermissionProvider.ViewUser))]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize, string filter = null, bool? isSystemAccount = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _userManager.Users;
                if (!string.IsNullOrEmpty(filter))
                    model = model.Where(x => x.UserName.Contains(filter) ||
                    x.FullName.Contains(filter));
                if (isSystemAccount != null)
                    model = model.Where(x => x.IsSystemAccount == isSystemAccount);
                model = model.OrderBy(x => x.UserName);
                var modelUser = model.ToPagedList(page + 1, pageSize);
                var modelVm = Mapper.Map<IEnumerable<AppUser>, IEnumerable<AppUserVm>>(modelUser.ToPagedList(1, pageSize));

                PaginationSet<AppUserVm> pagedSet = new PaginationSet<AppUserVm>()
                {
                    Page = page,
                    TotalCount = modelUser.TotalItemCount,
                    TotalPages = (int)Math.Ceiling((decimal)modelUser.TotalItemCount / pageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [Route("detail/{id}")]
        [HttpGet]
        [Authorize(Roles = nameof(PermissionProvider.ViewUser))]
        public HttpResponseMessage Details(HttpRequestMessage request, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, nameof(id) + " không có giá trị.");
            }
            var user = _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return request.CreateErrorResponse(HttpStatusCode.NoContent, "Không có dữ liệu");
            }
            else
            {
                var applicationUserViewModel = Mapper.Map<AppUser, AppUserVm>(user.Result);
                var listGroup = _appGroupService.GetListGroupByUserId(applicationUserViewModel.Id);
                applicationUserViewModel.Groups = Mapper.Map<IEnumerable<AppGroup>, IEnumerable<AppGroupVm>>(listGroup);
                return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);
            }

        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = nameof(PermissionProvider.AddUser))]
        public async Task<HttpResponseMessage> Create(HttpRequestMessage request, AppUserVm appUserVm)
        {
            if (ModelState.IsValid)
            {
                var newAppUser = new AppUser();
                newAppUser.UpdateUser(appUserVm);
                newAppUser.CreatedDate = GetDateTimeNowUTC();
                newAppUser.CreatedBy = User.Identity.GetUserId();
                newAppUser.IsSystemAccount = true;
                try
                {
                    newAppUser.Id = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(newAppUser, appUserVm.Password);
                    if (result.Succeeded)
                    {
                        var listAppUserGroup = new List<AppUserGroup>();
                        foreach (var group in appUserVm.Groups)
                        {
                            listAppUserGroup.Add(new AppUserGroup()
                            {
                                GroupId = group.Id,
                                UserId = newAppUser.Id
                            });
                            //add role to user
                            var listRole = _appRoleService.GetListRoleByGroupId(group.Id);
                            foreach (var role in listRole)
                            {
                                await _userManager.RemoveFromRoleAsync(newAppUser.Id, role.Name);
                                await _userManager.AddToRoleAsync(newAppUser.Id, role.Name);
                            }
                        }
                        _appGroupService.AddUserToGroups(listAppUserGroup, newAppUser.Id);

                        return request.CreateResponse(HttpStatusCode.OK, appUserVm);

                    }
                    else
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
                catch (Exception ex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("update")]
        [Authorize(Roles = nameof(PermissionProvider.EditUser))]
        public async Task<HttpResponseMessage> Update(HttpRequestMessage request, AppUserVm applicationUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByIdAsync(applicationUserViewModel.Id);
                RemoveAllRoleOfUser(appUser);
                try
                {
                    appUser.UpdateUser(applicationUserViewModel);
                    appUser.UpdatedDate = GetDateTimeNowUTC();
                    appUser.UpdatedBy = User.Identity.GetUserId();
                    var result = await _userManager.UpdateAsync(appUser);
                    if (result.Succeeded)
                    {
                        var listAppUserGroup = new List<AppUserGroup>();
                        foreach (var group in applicationUserViewModel.Groups)
                        {
                            listAppUserGroup.Add(new AppUserGroup()
                            {
                                GroupId = group.Id,
                                UserId = applicationUserViewModel.Id
                            });
                            //add role to user
                            var listRole = _appRoleService.GetListRoleByGroupId(group.Id);
                            foreach (var role in listRole)
                            {
                                await _userManager.AddToRoleAsync(appUser.Id, role.Name);
                            }
                        }
                        _appGroupService.AddUserToGroups(listAppUserGroup, applicationUserViewModel.Id);
                        return request.CreateResponse(HttpStatusCode.OK, applicationUserViewModel);

                    }
                    else
                        return request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join(",", result.Errors));
                }
                catch (NameDuplicatedException dex)
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, dex.Message);
                }
            }
            else
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("resetPassword")]
        [HttpPut]
        public async Task<HttpResponseMessage> ResetPassword(HttpRequestMessage request, AppUserVm userVm)
        {
            //var appUser = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            var remove = await _userManager.RemovePasswordAsync(userVm.Id);
            var passWord = DateTime.Now.ToString("ddMMyyyyss");
            var result = await _userManager.AddPasswordAsync(userVm.Id, passWord);

            if (result.Succeeded)
                return request.CreateResponse(HttpStatusCode.OK, passWord);
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, "Không cập nhật được password");

        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = nameof(PermissionProvider.DelUser))]
        public async Task<HttpResponseMessage> Delete(HttpRequestMessage request, string id)
        {
            var appUser = await _userManager.FindByIdAsync(id);
            appUser.IsActive = false;
            appUser.UpdatedDate = GetDateTimeNowUTC();
            var result = _userManager.Update(appUser);
            if (result.Succeeded)
                return request.CreateResponse(HttpStatusCode.OK, id);
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, string.Join(",", result.Errors));
        }

        [Route("changepassword")]
        [HttpPut]
        public async Task<HttpResponseMessage> ChangePassword(HttpRequestMessage request, PasswordVm PwdVM)
        {
            var appUser = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            var result = await _userManager.ChangePasswordAsync(appUser.Id, PwdVM.PasswordCurrent, PwdVM.PasswordNew);

            if (result.Succeeded)
                return request.CreateResponse(HttpStatusCode.OK, User.Identity.GetUserId());
            else
                return request.CreateErrorResponse(HttpStatusCode.OK, "Không cập nhật được password");

        }

        private void RemoveAllRoleOfUser(AppUser applicationUser)
        {
            var listRole = _userManager.GetRoles(applicationUser.Id);
            foreach (var role in listRole)
            {
                _userManager.RemoveFromRole(applicationUser.Id, role);
            }
        }
    }
}
