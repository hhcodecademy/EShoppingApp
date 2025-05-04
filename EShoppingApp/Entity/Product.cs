
using EShoppingApp.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EShoppingApp.Entity
{
    [EntityTypeConfiguration(typeof(ProductConfiguration))]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductDocument> ProductDocuments { get; set; }= new List<ProductDocument>();
    }

}
