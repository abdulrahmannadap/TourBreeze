using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourBreeze.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [ValidateNever]
        public string? ImageUrl { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string GoingUrl { get; set; } = string.Empty;



        public Countrie Countrie { get; set; } // Navigation property
        [ForeignKey(nameof(Countrie))] // Can also reference the navigation property
        public int CountrieId { get; set; }
    }
}
