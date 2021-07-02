using NBT.Core.Domain.Immigrant;
using NBT.Core.Services.ApplicationServices.Immigrant;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.Immigrant;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Immigrant
{
    public class VisaService : ServiceBase<Visa>, IVisaService
    {
        IVisaRepository _visaRepo;
        public VisaService(IUnitOfWork unitOfWork, IVisaRepository visaRepo) : base(unitOfWork, visaRepo)
        {
            _visaRepo = visaRepo;
        }

        public IEnumerable<Visa> GetAll(bool? isWeb = null)
        {
            var query = _visaRepo.TableNoTracking;
            return isWeb != null ? query.Where(x => x.IsWeb == isWeb.Value).ToList() : query.ToList();
        }

        public IPagedList<Visa> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "", bool? isWeb = null)
        {
            var query = _visaRepo.TableNoTracking;
            if (isWeb != null)
                query = query.Where(x=>x.IsWeb == isWeb.Value);
            if (!string.IsNullOrWhiteSpace(filter))
                query = query.Where(x => x.Name.Contains(filter));
            return query.OrderByDescending(x => x.DisplayOrder).ThenBy(x => x.Name).ToPagedList(pageIndex, pageSize);
        }

        public Visa GetByAlias(string alias)
        {
            return _visaRepo.GetMulti(x => x.Alias == alias).FirstOrDefault();
        }
    }
}
