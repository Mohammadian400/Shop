using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using Shop.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductController(ShopContext context)
        {
            _context = context;
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<ProdctViewModel>> GetTodoItem(long id)
        //{
        //    return _context.Products
        //.Include(s => s.Category)
        //           .Where(s => s.id ==id)
        //           .Select(s => new ProdctViewModel
        //           {

        //               ProductName = s.product.Name,
        //               BrandName = s.Product.BrandName,
        //               Description = s.Product.Description,
        //               //Day = s.Day,
        //               CategoryName = s.Category.CategoryName,



        //           }).ToList();
        //}
        [HttpPost]
        public async Task<ActionResult<long>> CreateProduct(ProdctViewModel prodview)
        {

            var product = new Product
            {
                ProductName = prodview.ProductName,
                BrandName = prodview.BrandName,
                Price = prodview.Price,
                Description = prodview.Description,
                CategoryId = prodview.CategoryId,

            };
            _context.Products.Add(product);

            // save changes
            await _context.SaveChangesAsync();
            return product.Id;

        }
        
        [HttpGet]
        public async Task<ActionResult<ProdctViewModel>> GetProduct(string prodName)
        {
            var result = 
                await _context.Products
                    .Include(s => s.Category)
                    .Where(s => prodName == null || s.ProductName.Contains(prodName))
                    .Select(s => new ProdctViewModel
                    {
                        ProductName = s.ProductName,
                        BrandName = s.BrandName,
                        Description = s.Description,
                        //Day = s.Day,
                        CategoryName = s.Category.CategoryName,
                    }).ToListAsync();
            
            return Ok(result);
            //var queryString = query.ToQueryString();

            //var products = from s in _context.Products
            //               where prodName == null || s.ProductName.Contains(prodName)
            //               select new ProdctViewModel
            //               {
            //                   ProductName = s.ProductName,
            //                   BrandName = s.BrandName,
            //                   Description = s.Description,
            //                  
            //                   CategoryName = s.Category.CategoryName,
            //               };

            //if (!string.IsNullOrEmpty(prodName))
            //{
            //    products = products.Where(s => s.ProductName.Contains(prodName));
            //}

            //queryString = products.ToQueryString();

            //var view = await products.AsNoTracking().ToListAsync();
            //return Ok(view);
        }
        [HttpGet]
        public async Task<ActionResult<ProdctViewModel>> GetProductByCategory([FromHeader]string categoryNames)
        {
            //var result =
            //    await _context.Products
            //        .Include(s => s.Category)
            //        .Where(s => (product1 == null || s.ProductName.Contains(product1)))
            //        .Select(s => new ProdctViewModel
            //        {
            //            ProductName = s.ProductName,
            //            BrandName = s.BrandName,
            //            Description = s.Description,
            //           //            CategoryName = s.Category.CategoryName,
            //        }).ToListAsync();

            //return Ok(result);

            var prodcts = (from p in _context.Products
                           where categoryNames.Any(s => (categoryNames == null) || p.Category.CategoryName.Contains(s))
                           select new ProdctViewModel
                           {
                               ProductName = p.ProductName,
                               BrandName = p.BrandName,
                               Description = p.Description,
                               CategoryName = p.Category.CategoryName

                           });

            // run query and get list
            var result = prodcts.ToList();

            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<ProdctViewModel>> GetSelectedProduct(long id)
        {
            var prod = await _context.Products.FindAsync(id);
            //return  _context.Products
            //        .Include(s => s.Category)
            //        .Where(s=>s.Id==id)
            //        .Select(s => new ProdctViewModel
            //        {
            //            ProductName = s.ProductName,
            //            BrandName = s.BrandName,
            //            Description = s.Description,
            //            CategoryName = s.Category.CategoryName,


            //        });

            var View = new ProdctViewModel
            {
                ProductName = prod.ProductName,
                BrandName = prod.BrandName,
                Description = prod.Description,
                CategoryName = prod.Category.CategoryName,
            };
            return Ok(View);
        }
        }
}
