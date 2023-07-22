using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using System.Collections.Generic;

namespace AdminPanel.Service.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private IOrderItemsRepository _repository;

        public OrderItemsService(IOrderItemsRepository repository)
        {
            _repository = repository;
        }

        public List<OrderBasket> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
