using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Models.Catalog
{
    public class MenuGeographyVm
    {
        public List<ContinentVm> Continents { set; get; }
        public List<CountryRegionVm> CountryRegions { set; get; }
        public List<StateProvinceVm> StateProvinces { set; get; }
        public List<AreaVm> Areas { set; get; }
        public MenuGeographyVm()
        {
            Continents = new List<ContinentVm>();
            CountryRegions = new List<CountryRegionVm>();
            StateProvinces = new List<StateProvinceVm>();
            Areas = new List<AreaVm>();
        }
    }
}