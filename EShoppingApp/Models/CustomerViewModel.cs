using System.ComponentModel.DataAnnotations;

namespace EShoppingApp.Models
{
    public class CustomerViewModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
            
      
    }
    
    
}
