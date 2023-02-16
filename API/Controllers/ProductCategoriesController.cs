using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductCategoriesController : BaseApiController
    {
        private readonly DataContext _context;
        public ProductCategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductCategory>>> GetProducts()
        {
            return await _context.ProductCategories
                .Include(p => p.Products)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProduct(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> AddCategory(ProductCategoryDTO productCategoryDTO)
        {
            if (await CategoryExists(productCategoryDTO.Name)) return BadRequest("This category is already exists");

            var category = new ProductCategory
            {
                Name = productCategoryDTO.Name
            };

            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;

        }

        private async Task<bool> CategoryExists(string name)
        {
            return await _context.ProductCategories.AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }

    }
}
