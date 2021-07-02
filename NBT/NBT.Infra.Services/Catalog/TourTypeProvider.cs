using NBT.Core.Domain.Catalog;
using NBT.Core.Services.ApplicationServices.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.Catalog
{
    public class TourTypeProvider : ITourTypeProvider
    {
        public static readonly TourType TravelTour = new TourType { Id = 1, Name = "Tour du lịch" };
        public static readonly TourType TicketTour = new TourType { Id = 2, Name = "Vé tham quan - Ghép tour" };
        public IEnumerable<TourType> GetAll()
        {
            return new[]
            {
                TravelTour,
                TicketTour
            };
        }
    }
}
