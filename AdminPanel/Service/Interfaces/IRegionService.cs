using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Service.Interfaces
{
    public interface IRegionService
    {
        List<Region> GetAll();

        List<Region> ReturnProductRegion(List<ProductAddress> list);
    }
}
