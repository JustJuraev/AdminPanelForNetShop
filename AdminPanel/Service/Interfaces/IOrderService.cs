using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Service.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll(Dictionary<string, string> filter);

        Order GetById(int id);

        List<OrderBasket> ReturnBasket(Order order);

        void Update(Order order);
    }
}
