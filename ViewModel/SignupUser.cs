using System.ComponentModel.DataAnnotations;

namespace thewayshop.ViewModel
{
    public class SignupUser
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required] public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password does not match!")]
        public string ConfirmPassword { get; set; }

        [Required] public string Email { get; set; }

        [Display(Name = "Phone Number")] public string PhoneNumber { get; set; }
    }
}