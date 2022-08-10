using System.ComponentModel.DataAnnotations;

namespace SmartShop_Ab.Models
{
    public class AddProduct
    {
        [Required]
        [Display(Name = "Product Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Brand Type")]
        public string BrandType { get; set; }
        [Required]
        [Display(Name = "Rate per Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Stock Count")]
        public float StockCount { get; set; }
    }
}
