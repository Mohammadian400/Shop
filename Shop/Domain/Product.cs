using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain
{
    public class Product
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
