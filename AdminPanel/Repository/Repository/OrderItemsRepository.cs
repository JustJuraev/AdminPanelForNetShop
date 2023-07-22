using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanel.Repository.Repository
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private ApplicationContext _context;

        public OrderItemsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<OrderBasket> GetAll()
        {
            return _context.OrderItems.ToList();
        }
    }
}
