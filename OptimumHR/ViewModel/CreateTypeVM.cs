using System.ComponentModel.DataAnnotations;

namespace OptimumHR.ViewModel
{
    public class CreateTypeVM
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}
