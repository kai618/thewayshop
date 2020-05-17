using System.ComponentModel.DataAnnotations;

namespace thewayshop.ViewModel
{
    public class SignupUser
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required] [MinLength(3)] public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password does not match!")]
        public string ConfirmPassword { get; set; }

        [Required] public string Email { get; set; }

        [Display(Name = "Phone Number")] public string PhoneNumber { get; set; }
    }

    public class SignInUser
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required] [MinLength(3)] public string Password { get; set; }
    }
}