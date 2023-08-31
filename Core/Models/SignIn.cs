using System.ComponentModel.DataAnnotations;

namespace CoreAuthentication.Models
{
    public class SignIn
    {
        [EmailAddress(ErrorMessage = "Valid Email required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Password required")]
        public String Password { get; set; }

    }
}
