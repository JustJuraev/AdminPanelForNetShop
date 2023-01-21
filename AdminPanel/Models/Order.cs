using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public bool Delivery { get; set; }

        public DateTime Date { get; set; }

        public List<string> Basket { get; set; }    

        public string CartNum { get; set; }

        public int TotalSum { get; set; }

        public short Status { get; set; }

        public string City { get; set; }
    }
}
