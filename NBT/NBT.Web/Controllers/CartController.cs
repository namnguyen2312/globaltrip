using AutoMapper;
using NBT.Core.Common;
using NBT.Core.Common.Helper;
using NBT.Core.Domain.Orders;
using NBT.Core.Services.ApplicationServices.Orders;
using NBT.Core.Services.Data;
using NBT.Web.Framework.Extensions;
using NBT.Web.Framework.Models.Cart;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class CartController : BaseController
    {
        IOrderService _orderService;
        IOrderItemService _orderItemService;
        IUnitOfWork _uow;
        public CartController(
            IOrderService orderService,
            IOrderItemService orderItemService,
            IUnitOfWork uow)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _uow = uow;
        }
        public ActionResult Index()
        {
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);
                return View(listItems);
            }
            this.LoadDefaultMetaSEO();
            return RedirectToAction("Index", "Tour");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(OrderItemVm item)
        {
            var cartCookie = CheckCart();
            if (item.FromDate.Date < DateTime.Now.Date)
                return Json(new
                {
                    Status = false
                });
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);

                if (listItems.Any(x => x.Alias == item.Alias && x.FromDate == item.FromDate))
                {
                    listItems.First(x => x.Alias == item.Alias && x.FromDate == item.FromDate).Quantity++;
                }
                else
                {
                    item.Quantity = 1;
                    item.Guid = Guid.NewGuid().ToString();
                    listItems.Add(item);
                }
                cartCookie.Value = JsonConvert.SerializeObject(listItems);
                cartCookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Set(cartCookie);
            }
            else
            {
                var listItems = new List<OrderItemVm>();
                item.Quantity = 1;
                item.Guid = Guid.NewGuid().ToString();
                listItems.Add(item);
                cartCookie.Value = JsonConvert.SerializeObject(listItems);
                cartCookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cartCookie);
            }
            return Json(new
            {
                Status = true
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(OrderVm order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);
                var newOrderItem = Mapper.Map<List<OrderItem>>(listItems);
                var newOrder = new Order();
                newOrder.UpdateOrder(order);
                newOrder.CreatedDate = DateTimeOffset.UtcNow;


                _uow.BeginTran();
                _orderService.Add(newOrder);
                foreach (var item in newOrderItem)
                {
                    item.FromDate = item.FromDate.Date;
                    //item.ToDate = item.ToDate.Date;
                    item.OrderId = newOrder.Id;
                }
                _orderItemService.Add(newOrderItem);
                _uow.CommitTran();
                cartCookie.Expires = DateTime.Now.AddDays(-180);
                Response.Cookies.Add(cartCookie);
                if (!string.IsNullOrEmpty(order.CustomerEmail))
                {
                    var settings = this.WebSetting;
                    MailHelper.SendMail(order.CustomerEmail, "Đặt chỗ tại Global Trip", "Cám ơn bạn đã đặt chỗ, chúng tôi sẽ liên lạc trong thời gian sớm nhất"
                        , settings.EmailAdmin
                        , settings.PasswordEmail
                        , "CÔNG TY TNHH THƯƠNG MẠI VÀ DỊCH VỤ DU LỊCH LỮ HÀNH TOÀN CẦU");
                    MailHelper.SendMail(this.WebSetting.EmailAdmin, "Đặt chỗ trên web Global Trip", "Khách hàng " + order.CustomerName + " đã đặt chỗ."
                        , settings.EmailAdmin
                        , settings.PasswordEmail
                        , "CTY Global Trip");
                }
                return RedirectToAction("Index", "Tour");
            }
            return RedirectToAction("Index", "Tour");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                this.LoadDefaultMetaSEO();
                var model = new OrderVm();
                return View(model);
            }
            return RedirectToAction("Index", "Tour");
        }

        [HttpDelete]
        public ActionResult DeleteItem(string id)
        {
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);
                var item = listItems.Where(x => x.Guid == id).First();
                listItems.Remove(item);
                
                if (listItems.Count > 0)
                {
                    cartCookie.Value = JsonConvert.SerializeObject(listItems);
                    cartCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Set(cartCookie);
                    return Json(new
                    {
                        Status = true
                    });
                }
                cartCookie.Expires = DateTime.Now.AddDays(-180);
                Response.Cookies.Add(cartCookie);
                
            }
            return Json(new
            {
                Status = false
            });
        }

        [HttpPut]
        public ActionResult RefreshItem(OrderItemVm item)
        {
            var cartCookie = CheckCart();
            if (cartCookie.Value != "")
            {
                var listItems = JsonConvert.DeserializeObject<List<OrderItemVm>>(cartCookie.Value);
                listItems.Where(x => x.Guid == item.Guid).First().Quantity = item.Quantity;

                if (listItems.Count > 0)
                {
                    cartCookie.Value = JsonConvert.SerializeObject(listItems);
                    cartCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Set(cartCookie);
                    return Json(new
                    {
                        Status = true
                    });
                }
                cartCookie.Expires = DateTime.Now.AddDays(-180);
                Response.Cookies.Add(cartCookie);
                
            }
            return Json(new
            {
                Status = false
            });
        }

        private HttpCookie CheckCart()
        {
            HttpCookie cartCookie;
            if (Request.Cookies[SystemConstants.Cart] != null)
                return Request.Cookies[SystemConstants.Cart];
            else
            {
                cartCookie = new HttpCookie(SystemConstants.Cart);
                cartCookie.Expires = DateTime.Now.AddDays(30);
                cartCookie.Value = "";
                return cartCookie;
            }
        }
    }
}