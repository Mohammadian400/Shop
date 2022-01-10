﻿
using System.Collections.Generic;

namespace Domain
{
    public class Category
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public object Product { get; set; }
    }
   
}
