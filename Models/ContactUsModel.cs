using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BourneCars.Models
{
    public class ContactUsModel
    {
        [Required]
        [Display(Name = "Your Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Your Email Address" )]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Your Email Address")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Your Message...")]
        public string Message { get; set; }
    }
}