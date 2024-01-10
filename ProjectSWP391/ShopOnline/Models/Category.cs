using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [StringLength(20, ErrorMessage = "Category Name cannot be longer than 20 characters")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
