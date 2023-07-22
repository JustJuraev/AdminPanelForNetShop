using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Service.Interfaces
{
    public interface IOrderItemsService
    {
        List<OrderBasket> GetAll();
    }
}
