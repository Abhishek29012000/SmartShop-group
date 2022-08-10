using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop_Ab.Models
{
    public class StockManagement
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        [Required]
    
        public string  ProductName { get; set; }
     
        public string ProductImage { get; set; }
        [Display(Name = "Rate per Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Stock Count")]
        [Required]
      
        public float StockCount { get; set; }
     
        [Required]
        [Display(Name = "Manufacturing Date")]
        public DateTime MDate { get; set; }
        [Required]
        [Display(Name = "Expire Date")]
        public DateTime EDate { get; set; }

    }
}
