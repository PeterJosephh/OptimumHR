using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class PreformanceReview
    {
        public int Id { get; set; }

        [StringLength(2)]
        public int Rating { get; set; }
        public string? Comment { get; set; }
        [ForeignKey("Employee")]

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
