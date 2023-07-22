using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) 
        { 
           _orderRepository = orderRepository;
        }

        public List<Order> GetAll(Dictionary<string, string> filter)
        {
           return _orderRepository.GetAll(filter);
        }

        public Order GetById(int id)
        {
           return _orderRepository.GetById(id);
        }

        public List<OrderBasket> ReturnBasket(int id)
        {
            return _orderRepository.ReturnBasket(id);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
