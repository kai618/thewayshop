using System.ComponentModel.DataAnnotations;

namespace thewayshop.ViewModel
{
    public class SignupUser
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required] [MinLength(6)] public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password does not match!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"(0|(\+84))[1-9]+([0-9]{8})\b", ErrorMessage = "This field does not match Vietnamese phone number format!")]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }


    public class SignInUser
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required] [MinLength(3)] public string Password { get; set; }
    }
}