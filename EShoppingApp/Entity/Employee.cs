namespace EShoppingApp.Entity
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }      
        public decimal Salary { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
    
}
