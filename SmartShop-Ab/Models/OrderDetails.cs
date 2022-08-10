﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop_Ab.Models
{
    public class OrderDetails
    {

        public int Id { get; set; }
        [Display(Name = "Order")]
        public int OrderId { get; set; }
        
     

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
     
    }
}
