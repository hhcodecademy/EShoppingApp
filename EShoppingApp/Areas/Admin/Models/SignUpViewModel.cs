using System.ComponentModel.DataAnnotations;

namespace EShoppingApp.Areas.Admin.Models
{
    public class SignUpViewModel
    {
        [Required()]
        [StringLength(255, MinimumLength = 5)]
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required()]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{8}$")]
        [Required()]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required()]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
