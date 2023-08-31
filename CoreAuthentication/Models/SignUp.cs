using System.ComponentModel.DataAnnotations;

namespace CoreAuthentication.Models
{
    public class SignUp
    {
        [Required(ErrorMessage = "First name required")]
        public String FirstName { get; set; }
        [Required(ErrorMessage = "Last name required")]
        public String LastName { get; set; }
        [Required(ErrorMessage = "Email address required")]
        [EmailAddress]
        public String Email { get; set; }

        //Implement the Pattern for the 'Password' here

        [Required(ErrorMessage = "Password required")]
        public String Password { get; set; }        
        [Required(ErrorMessage = "Confirm password required")]
        [Compare("Password")]
        public String ConfirmPassword { get; set; }

        public string[] Roles { get; set; }
    }
}
