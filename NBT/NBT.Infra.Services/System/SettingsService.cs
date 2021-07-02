using NBT.Core.Domain.System;
using NBT.Core.Services.ApplicationServices.System;
using NBT.Core.Services.Data;
using NBT.Core.Services.DomainServices.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.System
{
    public class SettingsService : ServiceBase<Settings>, ISettingsService
    {
        ISettingsRepository _settingsRepo;
        ISettingsProvider _settingsProvider;
        public SettingsService(IUnitOfWork unitOfWork
            , ISettingsRepository settingsRepo
            , ISettingsProvider settingsProvider) : base(unitOfWork, settingsRepo)
        {
            _settingsRepo = settingsRepo;
            _settingsProvider = settingsProvider;
        }

        public IEnumerable<Settings> GetAll()
        {
            return _settingsRepo.TableNoTracking.ToList();
        }

        public void InsertFromSystem()
        {
            var settingDefault = _settingsProvider.GetAll();
            var modelSettings = _settingsRepo.TableNoTracking.ToList();

            settingDefault = settingDefault.Where(x => !modelSettings.Select(b => b.Id).Contains(x.Id));
            foreach (var item in settingDefault)
            {
                _settingsRepo.Insert(item);
            }
        }

    }
}
