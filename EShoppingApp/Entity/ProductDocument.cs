namespace EShoppingApp.Entity
{
    public class ProductDocument: BaseEntity
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
  
}
