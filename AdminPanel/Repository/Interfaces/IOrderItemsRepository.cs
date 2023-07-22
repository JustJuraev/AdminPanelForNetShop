using AdminPanel.Models;
using System.Collections.Generic;

namespace AdminPanel.Repository.Interfaces
{
    public interface IOrderItemsRepository
    {
        List<OrderBasket> GetAll();
    }
}
