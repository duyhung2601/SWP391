using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "RequiredDate")]
        public DateTime? RequiredDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Shipped Date")]
        public DateTime? ShippedDate { get; set; }
        public string Freight { get; set; }
        [StringLength(50, ErrorMessage = "Shipp Address cannot be longer than 50 characters")]
        [Display(Name = "Ship Address")]
        public string ShipAddress { get; set; }
        public Account Account { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
