using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ProductCategoryDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
