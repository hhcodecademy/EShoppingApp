using System.ComponentModel;

namespace EShoppingApp.Models
{
    public class CategoryViewModel
    {

        public int Id { get; set; }
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Aciqlama")]
        public string Description { get; set; }
        public int ParentId { get; set; }

        [DisplayName("Resm")]
        public IFormFile ImageFile { get; set; }
        public string ImageUrl { get; set; }

        public List<CategoryViewModel> ParentCategories { get; set; }
    }
}
