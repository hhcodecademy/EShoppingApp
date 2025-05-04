using System.ComponentModel;
using EShoppingApp.Entity;

namespace EShoppingApp.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
