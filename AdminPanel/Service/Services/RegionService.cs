using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class RegionService : IRegionService
    {
        private IRegionRepostiory _regionRepostiory;

        public RegionService(IRegionRepostiory regionRepostiory)
        {
            _regionRepostiory = regionRepostiory;
        }

        public List<Region> GetAll()
        {
            return _regionRepostiory.GetAll();
        }

        public List<Region> ReturnProductRegion(List<ProductAddress> list)
        {
            return _regionRepostiory.ReturnProductRegion(list);
        }
    }
}
