using System;
using System.ComponentModel.DataAnnotations;


namespace TJphonehub.Entity
{
    public class ProductSales
    {
      
        public int Id { get; set; } 
        public string? PaymentType { get; set; }
        public int NetCost { get; set; }
        public int TotalQuantity { get; set; }

    }
}
