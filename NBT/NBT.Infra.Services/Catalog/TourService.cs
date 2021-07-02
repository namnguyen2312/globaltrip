using NBT.Core.Domain.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Catalog;
using PagedList;
using NBT.Core.Domain.Catalog.Dto;

namespace NBT.Infra.Services.Catalog
{
    public class TourService : ServiceBase<Tour>, ITourService
    {
        ITourRepository _tourRepo;
        ITourAttributeRepository _tourAttributeRepository;
        ITourAttributeValueRepository _tourAttributeValueRepository;
        ICountryRegionRepository _countryRegionRepository;
        IStateProvinceRepository _stateProvinceRepository;
        public TourService(IUnitOfWork unitOfWork
            , ITourRepository tourRepo
            , ITourAttributeValueRepository tourAttributeValueRepository
            , ITourAttributeRepository tourAttributeRepository
            , ICountryRegionRepository countryRegionRepository
            , IStateProvinceRepository stateProvinceRepository) : base(unitOfWork, tourRepo)
        {
            _tourRepo = tourRepo;
            _tourAttributeRepository = tourAttributeRepository;
            _tourAttributeValueRepository = tourAttributeValueRepository;
            _countryRegionRepository = countryRegionRepository;
            _stateProvinceRepository = stateProvinceRepository;
        }
        public TourDto GetById(long id)
        {
            var query = (from t in _tourRepo.TableNoTracking.Where(x => x.Id == id)
                         join c in _countryRegionRepository.TableNoTracking on t.CountryRegionId equals c.Id
                         join s in _stateProvinceRepository.TableNoTracking on t.StateProvinceId equals s.Id
                         select new TourDto
                         {
                             Id = t.Id,
                             Alias = t.Alias,
                             Code = t.Code,
                             CountryRegionId = t.CountryRegionId,
                             CreatedBy = t.CreatedBy,
                             CreatedDate = t.CreatedDate,
                             DescriptionSeo = t.DescriptionSeo,
                             FromDate = t.FromDate,
                             FullDescription = t.FullDescription,
                             Image = t.Image,
                             IsDel = t.IsDel,
                             IsShow = t.IsShow,
                             KeywordSeo = t.KeywordSeo,
                             Name = t.Name,
                             ShortDescription = t.ShortDescription,
                             StateProvinceId = t.StateProvinceId,
                             TitleSeo = t.TitleSeo,
                             ToDate = t.ToDate,
                             UpdatedBy = t.UpdatedBy,
                             UpdatedDate = t.UpdatedDate,
                             Price = t.Price,
                             DisplayOrder = t.DisplayOrder,
                             IsHot = t.IsHot,
                             TotalDays = t.TotalDays,
                             CountryRegionName = c.Name,
                             StateProvinceName = s.Name,
                             LargeImage = t.LargeImage,
                             TourType = t.TourType,
                             DayBegin = t.DayBegin,
                             AreaId = t.AreaId,
                             EventTitle = t.EventTitle
                         }).FirstOrDefault();
            var modelAttr = from attr in _tourAttributeValueRepository.TableNoTracking.Where(x => x.TourId == id)
                            join attrs in _tourAttributeRepository.TableNoTracking on attr.TourAttributeId equals attrs.Id
                            select new TourAttributeValueDto
                            {
                                AttrName = attrs.Name,
                                Id = attr.Id,
                                TourAttributeId = attrs.Id,
                                TourId = attr.TourId,
                                Value = attr.Value
                            };
            query.TourAttr = modelAttr.ToList();
            return query;
        }
        public IPagedList<Tour> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", int stateProvinceId = 0, int countryRegionId = 0, int tourType = 0)
        {
            var query = _tourRepo.TableNoTracking.Where(x => x.IsDel == false);
            if (tourType != 0)
                query = query.Where(x => x.TourType == tourType);
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter) || x.Code.Contains(filter));
            if (stateProvinceId != 0)
                query = query.Where(x => x.StateProvinceId == stateProvinceId);
            if (countryRegionId != 0)
                query = query.Where(x => x.CountryRegionId == countryRegionId);

            return query.OrderByDescending(x => x.DisplayOrder).ThenByDescending(x => x.CreatedDate).ThenBy(x => x.Name).ToPagedList(pageIndex, pageSize);
        }

        public void DeleteById(long id)
        {
            try
            {
                var model = _tourRepo.GetById(id);
                model.IsDel = true;
                _tourRepo.Update(model);
            }
            catch
            {
                throw;
            }
        }

        public IPagedList<TourDto> GetAll(int pageIndex = 1, int pageSize = 20, string filter = ""
            , int stateProvinceId = 0, int countryRegionId = 0
            , bool? isShow = null, int tourType = 0, int areaId = 0, bool? isDomestic = null)
        {
            var query = _tourRepo.TableNoTracking.Where(x => x.IsDel == false);
            var queryCountryRegion = _countryRegionRepository.TableNoTracking;
            if (isDomestic != null)
                queryCountryRegion = _countryRegionRepository.TableNoTracking.Where(x => x.Domestic == isDomestic);
            if (tourType != 0)
                query = query.Where(x => x.TourType == tourType);
            if (isShow != null)
                query = query.Where(x => x.IsShow == isShow.Value);
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));
            if (stateProvinceId != 0)
                query = query.Where(x => x.StateProvinceId == stateProvinceId);
            if (countryRegionId != 0)
                query = query.Where(x => x.CountryRegionId == countryRegionId);
            if (areaId != 0)
                query = query.Where(x => x.AreaId == areaId);
            var queryResult = from t in query
                              join c in queryCountryRegion on t.CountryRegionId equals c.Id
                              join s in _stateProvinceRepository.TableNoTracking on t.StateProvinceId equals s.Id
                              select new TourDto
                              {
                                  Id = t.Id,
                                  Alias = t.Alias,
                                  Code = t.Code,
                                  CountryRegionId = t.CountryRegionId,
                                  CreatedBy = t.CreatedBy,
                                  CreatedDate = t.CreatedDate,
                                  DescriptionSeo = t.DescriptionSeo,
                                  FromDate = t.FromDate,
                                  FullDescription = t.FullDescription,
                                  Image = t.Image,
                                  IsDel = t.IsDel,
                                  IsShow = t.IsShow,
                                  KeywordSeo = t.KeywordSeo,
                                  Name = t.Name,
                                  ShortDescription = t.ShortDescription,
                                  StateProvinceId = t.StateProvinceId,
                                  TitleSeo = t.TitleSeo,
                                  ToDate = t.ToDate,
                                  UpdatedBy = t.UpdatedBy,
                                  UpdatedDate = t.UpdatedDate,
                                  Price = t.Price,
                                  DisplayOrder = t.DisplayOrder,
                                  IsHot = t.IsHot,
                                  TotalDays = t.TotalDays,
                                  CountryRegionName = c.Name,
                                  StateProvinceName = s.Name,
                                  LargeImage = t.LargeImage,
                                  TourType = t.TourType,
                                  DayBegin = t.DayBegin,
                                  AreaId = t.AreaId,
                                  EventTitle = t.EventTitle
                              };
            return queryResult.OrderByDescending(x => x.DisplayOrder)
                .ThenByDescending(x => x.CreatedDate)
                .ThenBy(x => x.Name).ToPagedList(pageIndex, pageSize);
        }

        public TourDto GetByAlias(string alias)
        {
            var query = (from t in _tourRepo.TableNoTracking.Where(x => x.Alias == alias)
                         join c in _countryRegionRepository.TableNoTracking on t.CountryRegionId equals c.Id
                         join s in _stateProvinceRepository.TableNoTracking on t.StateProvinceId equals s.Id
                         select new TourDto
                         {
                             Id = t.Id,
                             Alias = t.Alias,
                             Code = t.Code,
                             CountryRegionId = t.CountryRegionId,
                             CreatedBy = t.CreatedBy,
                             CreatedDate = t.CreatedDate,
                             DescriptionSeo = t.DescriptionSeo,
                             FromDate = t.FromDate,
                             FullDescription = t.FullDescription,
                             Image = t.Image,
                             IsDel = t.IsDel,
                             IsShow = t.IsShow,
                             KeywordSeo = t.KeywordSeo,
                             Name = t.Name,
                             ShortDescription = t.ShortDescription,
                             StateProvinceId = t.StateProvinceId,
                             TitleSeo = t.TitleSeo,
                             ToDate = t.ToDate,
                             UpdatedBy = t.UpdatedBy,
                             UpdatedDate = t.UpdatedDate,
                             Price = t.Price,
                             DisplayOrder = t.DisplayOrder,
                             IsHot = t.IsHot,
                             TotalDays = t.TotalDays,
                             CountryRegionName = c.Name,
                             StateProvinceName = s.Name,
                             LargeImage = t.LargeImage,
                             TourType = t.TourType,
                             DayBegin = t.DayBegin,
                             AreaId = t.AreaId,
                             EventTitle = t.EventTitle
                         }).FirstOrDefault();
            var modelAttr = from attr in _tourAttributeValueRepository.TableNoTracking.Where(x => x.TourId == query.Id)
                            join attrs in _tourAttributeRepository.TableNoTracking on attr.TourAttributeId equals attrs.Id
                            select new TourAttributeValueDto
                            {
                                AttrName = attrs.Name,
                                Id = attr.Id,
                                TourAttributeId = attrs.Id,
                                TourId = attr.TourId,
                                Value = attr.Value
                            };
            query.TourAttr = modelAttr.ToList();
            return query;
        }

        public bool CheckCode(string code)
        {
            code = code.Trim().ToUpper();
            var query = _tourRepo.TableNoTracking.Where(x => x.Code == code).ToList();
            return query.Count > 0;
        }

        public IEnumerable<Tour> GetHomeTop(int top = 1)
        {
            var query = _tourRepo.TableNoTracking.Where(x => x.IsDel == false && x.IsShow == true && x.IsHot == true);
            return query.OrderBy(x => x.Name).Take(top);
        }
    }
}
