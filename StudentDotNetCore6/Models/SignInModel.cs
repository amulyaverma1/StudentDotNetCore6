using System.ComponentModel.DataAnnotations;

namespace StudentDotNetCore6.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Please enter a valid email"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="password must be alphanumeric")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
