using AutoMapper;
using NBT.Core.Domain.Catalog.Dto;
using NBT.Core.Services.ApplicationServices.Catalog;
using NBT.Infra.Services.Catalog;
using NBT.Web.Framework.Core;
using NBT.Web.Framework.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class TicketController : BaseController
    {
        IContinentService _continentService;
        ICountryRegionService _countryRegionService;
        IStateProvinceService _stateProvinceService;
        IAreaService _areaService;
        ITourService _tourService;
        public TicketController(
            IContinentService continentService,
            ICountryRegionService countryRegionService,
            IStateProvinceService stateProvinceService,
            IAreaService areaService,
            ITourService tourService
            )
        {
            _continentService = continentService;
            _countryRegionService = countryRegionService;
            _stateProvinceService = stateProvinceService;
            _areaService = areaService;
            _tourService = tourService;
        }

        public ActionResult Index(int pageIndex = 1, int pageSize = 12, string filter = "", int stateProvinceId = 0, int countryRegionId = 0, int areaId = 0)
        {
            var model = _tourService.GetAll(pageIndex, pageSize, filter, stateProvinceId, countryRegionId, true, TourTypeProvider.TicketTour.Id, areaId);

            string queryParams = "";
            if (!string.IsNullOrWhiteSpace(filter))
                queryParams += "&filter=" + filter;
            if (stateProvinceId != 0)
                queryParams += "&stateProvinceId=" + stateProvinceId;
            if (countryRegionId != 0)
                queryParams += "&countryRegionId=" + countryRegionId;
            if (areaId != 0)
                queryParams += "&areaId=" + areaId;
            ViewBag.queryParams = queryParams;
            ViewBag.countryRegions = _countryRegionService.GetAll(true);
            PaginationSet<TourDto> pagedSet = new PaginationSet<TourDto>()
            {
                Page = pageIndex,
                TotalCount = model.TotalItemCount,
                TotalPages = (int)Math.Ceiling((decimal)model.TotalItemCount / pageSize),
                Items = model
            };
            this.LoadDefaultMetaSEO();
            return View(pagedSet);
        }
        public ActionResult Detail(string alias)
        {
            var model = _tourService.GetByAlias(alias);
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult ForeignCategory()
        {
            MenuGeographyVm model = new MenuGeographyVm();
            var modelContinent = _continentService.GetAll(true);
            var modelCountryRegion = _countryRegionService.GetAll(true);
            var modelStateProvince = _stateProvinceService.GetAll(true);
            var modelArea = _areaService.GetAll(true);
            model.Continents = Mapper.Map<List<ContinentVm>>(modelContinent);
            model.CountryRegions = Mapper.Map<List<CountryRegionVm>>(modelCountryRegion);
            model.StateProvinces = Mapper.Map<List<StateProvinceVm>>(modelStateProvince);
            model.Areas = Mapper.Map<List<AreaVm>>(modelArea);
            return PartialView(model);
        }
    }
}