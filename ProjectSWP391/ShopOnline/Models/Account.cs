using System.ComponentModel.DataAnnotations;

namespace ShopOnline.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Username cannot be longer than 20 characters")]
        public string UserName { get; set; }
        [StringLength(20, ErrorMessage = "Password cannot be longer than 20 characters")]
        public string Password { get; set; }
        [StringLength(20, ErrorMessage = "Fullname cannot be longer than 20 characters")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime Dob { get; set; }
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Phone must be between 10 and 12 characters")]
        public string Phone { get; set; }
        public Type Type { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
    public enum Type
    {
        STAFF = 0,
        MEMBER = 1
    }
}

