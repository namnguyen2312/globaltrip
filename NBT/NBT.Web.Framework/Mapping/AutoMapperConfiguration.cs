using AutoMapper;
using NBT.Core.Domain.Catalog;
using NBT.Core.Domain.Catalog.Dto;
using NBT.Core.Domain.Identity;
using NBT.Core.Domain.Orders;
using NBT.Web.Framework.Models.Cart;
using NBT.Web.Framework.Models.Catalog;
using NBT.Web.Framework.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AppUser, AppUserVm>();
                cfg.CreateMap<AppGroup, AppGroupVm>();
                cfg.CreateMap<TourDto, Tour>();
                cfg.CreateMap<TourAttributeValueDto, TourAttributeValue>();
                cfg.CreateMap<OrderVm, Order>();
                cfg.CreateMap<OrderItemVm, OrderItem>()
                .ForMember(x => x.CodeId, mo => mo.MapFrom(src => src.Id))
                .ForMember(x => x.Image, mo => mo.MapFrom(src => src.Image))
                .ForMember(x => x.Quantity, mo => mo.MapFrom(src => src.Quantity))
                .ForMember(x => x.Price, mo => mo.MapFrom(src => src.Price))
                .ForMember(x => x.FromDate, mo => mo.MapFrom(src => src.FromDate))
                .ForMember(x => x.ToDate, mo => mo.MapFrom(src => src.ToDate))
                .ForMember(x => x.Code, mo => mo.MapFrom(src => src.Code))
                ;
                cfg.CreateMap<Continent, ContinentVm>();
                cfg.CreateMap<CountryRegion, CountryRegionVm>();
                cfg.CreateMap<StateProvince, StateProvinceVm>();
                cfg.CreateMap<Area, AreaVm>();
            });
        }
    }
}