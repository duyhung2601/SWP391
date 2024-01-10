using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [StringLength(50, ErrorMessage = "Company Name cannot be longer than 50 characters")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters")]
        public string Address { get; set; }
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Phone must be between 10 and 12 characters")]
        public string Phone { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
