using System.ComponentModel;
using EShoppingApp.Entity;

namespace EShoppingApp.Models
{
    public class OrderViewModel
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        [DisplayName("Costumer Name")]
        public int CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }

        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public ICollection<CustomerViewModel> Customers { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
