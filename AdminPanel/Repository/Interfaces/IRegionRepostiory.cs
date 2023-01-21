using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Repository.Interfaces
{
    public interface IRegionRepostiory
    {
        List<Region> GetAll();

        List<Region> ReturnProductRegion(List<ProductAddress> list);
    }
}
