using System.ComponentModel.DataAnnotations;

namespace SmartShop_Ab.Models
{
    public class UserMaster
    {


        [Required(ErrorMessage = "Id is Required")]
        [Display(Name = "Id*")]
        public int Id { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        [Display(Name = "FirstName*")]
        public string fName { get; set; }

        [Required(ErrorMessage = "LastName is Required")]
        [Display(Name = "LastName*")]
        public string LName { get; set; }

        //[Required(ErrorMessage = "Date of Birth is Required")]
        [Display(Name = "DoB*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "(0:MM/dd/yyy)")]
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        [Display(Name = "Gender*")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Mobile No. is Required")]
        [RegularExpression("[6-9]{1}[0-9]{9}", ErrorMessage = "Invalid Mobile No.")]
        [Display(Name = "Mobile No.*")]
        public Int64 Contactnumber { get; set; }
        [Required(ErrorMessage = "Email is Required")]

        [Display(Name = "Email*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserId is Required")]
        [Display(Name = "UserId*")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [Display(Name = "Confirm Password*")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password should be same")]
        public string CPassword { get; set; }

        [Required(ErrorMessage = "Confirm User Category is Required")]
        [Display(Name = "User Category*")]

        public string UserCategory { get; set; }
        public int RoleID { get; set; }
    }
}
