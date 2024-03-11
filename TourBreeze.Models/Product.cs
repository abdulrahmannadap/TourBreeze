using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TourBreeze.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
        //public double LiksCount { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string GoingUrl { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string City { get; set; }


    }
}
