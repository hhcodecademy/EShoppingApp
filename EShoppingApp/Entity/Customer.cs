namespace EShoppingApp.Entity
{
    public class Customer: Person
    {
        public string Address { get; set; }     
        public ICollection<Order> Orders { get; set; } = new List<Order>();
         
    }
}
