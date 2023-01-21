using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using AdminPanel.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Telegram.Bot;

namespace AdminPanel.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
      

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index(Dictionary<string,string> filter)
        {
           
            return View(_orderService.GetAll(filter));
        }

        public IActionResult BasketDetails(int id) 
        {
            return View(_orderService.ReturnBasket(_orderService.GetById(id)));
        }

        public IActionResult Update(int id)
        {
            return View(_orderService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Order order) 
        { 
            _orderService.Update(order);

            return RedirectToAction("Index");
        }
    }
}
