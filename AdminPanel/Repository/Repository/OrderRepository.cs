using AdminPanel.Models;
using AdminPanel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminPanel.Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Order> GetAll(Dictionary<string, string> filter) 
        {
            var query = _context.Orders.AsNoTracking();
            if(filter.ContainsKey("id") && filter["id"] != null)
            {
                query = query.Where(x => x.Id == Int32.Parse(filter["id"]));
            }
            if (filter.ContainsKey("address") && filter["address"] != null)
            {
                query = query.Where(x => x.Address.Contains(filter["address"]));
            }
            if (filter.ContainsKey("phone") && filter["phone"] != null)
            {
                query = query.Where(x => x.Number == filter["phone"]);
            }
            if (filter.ContainsKey("date_start") && filter["date_start"] != null)
            {
                var date_start = DateTime.Parse(filter["date_start"]);
                query = query.Where(x => x.Date > date_start);
            }
            if (filter.ContainsKey("date_end") && filter["date_end"] != null)
            {
                var date_end = DateTime.Parse(filter["date_end"]);
                query = query.Where(x => x.Date < date_end);
            }
            if (filter.ContainsKey("cart_num") && filter["cart_num"] != null)
            {
                query = query.Where(x => x.CartNum == filter["cart_num"]);
            }
            if (filter.ContainsKey("sum") && filter["sum"] != null)
            {
                query = query.Where(x => x.TotalSum == Int32.Parse(filter["sum"]));
            }
            if (filter.ContainsKey("status") && filter["status"] != null)
            {
                if (filter["status"] == "delivered")
                {
                    query = query.Where(x => x.Status == 10);
                }
                else if (filter["status"] == "not_delivered")
                {
                    query = query.Where(x => x.Status == 20);
                }
                else if (filter["status"] == "canseled")
                {
                    query = query.Where(x => x.Status == 30);   
                }
            }
            return query.OrderBy(x => x.Id).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x=> x.Id == id);
        }

        public void Update(Order order) 
        { 
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public List<OrderBasket> ReturnBasket(Order order)
        {
            List<OrderBasket> list = new List<OrderBasket>();
            foreach(var item in order.Basket)
            {
                var str = _context.Products.FirstOrDefault(x => x.Id == Int32.Parse(item[0].ToString()));
                list.Add(new OrderBasket { Name = str.Name, Count = Int32.Parse(item[2].ToString()) });
            }

            return list;
        }
    }
}
