namespace EShoppingApp.Entity
{
    public class Order : BaseEntity
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
      public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
      
    }
    
}
