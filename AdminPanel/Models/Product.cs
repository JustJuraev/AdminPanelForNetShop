using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanel.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int BarCode { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int PriceIncome { get; set; }

        public int PriceOutCome { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public int CategoryId { get; set; }

        public int Count { get; set; }

        public int StockId { get; set; }

        [NotMapped]
        public IFormFile CoverPhoto { get; set; }

    }
}
