using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Domain.ViewModel
{
    public class ProdctViewModel
    {

        [Required]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(30)]
        public string BrandName { get; set; }
        [Required]
        [Range(1, 9999999)]
        public decimal Price { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }
        [Required]
        public long CategoryId { get; set; }
    }
}
