using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ShopOnline.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Slider Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
