using System.ComponentModel.DataAnnotations;

namespace OptimumHR.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Enter Your Username")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
