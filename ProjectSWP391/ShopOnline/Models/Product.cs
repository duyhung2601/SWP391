using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [StringLength(50, ErrorMessage = "Product Name cannot be longer than 50 characters")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }

        public string ProductImage { get; set; }
        public Supplier? Supplier { get; set; }
        public Category? Category { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
