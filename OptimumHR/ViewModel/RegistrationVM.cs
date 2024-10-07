using System.ComponentModel.DataAnnotations;

namespace OptimumHR.ViewModel
{
    public class RegistrationVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password", ErrorMessage = "Password Don't match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string role {get;set;}

    }
}
