using System.ComponentModel.DataAnnotations;

namespace OptimumHR.ViewModel
{
    public class CreateRoleVM
    {
        [Required]
        public string role { get; set; }

    }
}
