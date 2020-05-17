using System.ComponentModel.DataAnnotations;

namespace thewayshop.ViewModel
{
    public class SignupUser
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
        [Required] public string ConfirmPassword { get; set; }
        [Required] public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}