using System.ComponentModel.DataAnnotations;

namespace SmartShop_Ab.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Product Type")]
        public string ProductType { get; set; }
    }
}
