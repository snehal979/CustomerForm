using System.ComponentModel.DataAnnotations;

namespace CustomerForm.Models
{
    public class Customer
    {
        //Model
        //Validation
        [Key]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "CustomerName is required")]
        [StringLength(50, ErrorMessage = "Name should be between 1 and 50 characters", MinimumLength = 1)]
        public string CustomerName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "CustomerEmail is required")]
        public string CustomerEmail { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Required(ErrorMessage = "MobileNumber is required")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Image Url")]
        public string ProfileImg { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
      
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Invalid Address")]
        [StringLength(100, ErrorMessage = "Address should be between 5 and 100 characters", MinimumLength = 5)]
        public string CustomerAddress { get; set; }
    }
}
