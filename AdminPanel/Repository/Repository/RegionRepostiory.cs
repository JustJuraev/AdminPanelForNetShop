using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanel.Repository.Repository
{
    public class RegionRepostiory : IRegionRepostiory
    {
        private ApplicationContext _context;

        public RegionRepostiory(ApplicationContext context)
        {
            _context = context;
        }

        public List<Region> GetAll()
        {
            return _context.Regions.AsNoTracking().ToList();
        }

        public List<Region> ReturnProductRegion(List<ProductAddress> list)
        {
            var regionsId = list.Select(x => x.RegionId).ToList();
            var regions = new List<Region>();
            foreach(var region in regionsId) 
            {
                var current_region = _context.Regions.FirstOrDefault(x => x.Id == region);
                regions.Add(current_region);
            }
            
            return regions;
        }
    }
}
