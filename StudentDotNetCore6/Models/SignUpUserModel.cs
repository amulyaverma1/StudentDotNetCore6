using System.ComponentModel.DataAnnotations;

namespace StudentDotNetCore6.Models
{
    public class SignUpUserModel
    {
        [Required (ErrorMessage = "Please enter your Email address")]
        [EmailAddress (ErrorMessage ="Please enter a valid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [DataType (DataType.Password)]
        public string Password { get; set; }
            
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage ="Password does not match")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
