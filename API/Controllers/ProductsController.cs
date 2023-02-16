using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(ProductDTO productDTO)
        {
            if (await ProductExists(productDTO.Name)) return BadRequest("This product is already exists");
            if (!(await CategoryByIdExists(productDTO.ProductCategoryId))) return BadRequest("No such category exists");

            var product = new Product
            {
                Name = productDTO.Name,
                Price= productDTO.Price,
                ProductCategoryId = productDTO.ProductCategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return product;

        }

        private async Task<bool> ProductExists(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name.ToLower() == name.ToLower());
        }

        private async Task<bool> CategoryByIdExists(int id)
        {
            return await _context.Products.AnyAsync(p => p.Id == id);
        }
    }
}
