using System.ComponentModel.DataAnnotations;

namespace SmartShop_Ab.Models
{
    public class Login
    {

        [Key]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Password id Required")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
