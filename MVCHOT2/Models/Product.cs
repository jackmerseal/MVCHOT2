using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace MVCHOT2.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string ProductName { get; set; } = "";
        public string? ProductDescShort { get; set; } = "";
        public string? ProductDescLong { get; set; } = "";
        [Required(ErrorMessage = "Please enter an image")]
        public string ProductImage { get; set; } = "";
        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal ProductPrice { get; set; } = 0.00M;
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1000")]
        public int ProductQty { get; set; } = 0;

        public string Slug => ProductName?.Replace(' ', '-').ToLower() + '-';

        public int CategoryID { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;
    }
}
