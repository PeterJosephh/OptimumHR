using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class PermissionReq
    {
        public int Id { get; set; }

        [Required]
        public DateOnly Date { get; set; }
        [Required]

        public TimeOnly StartTime { get; set; }
        [Required]

        public TimeOnly EndTime { get; set; }
        [Required]

        public string Description { get; set; }


        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }


        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }


        [ForeignKey("Status")]
        public int? StatusId { get; set; }
        public RequestStatus? Status { get; set; }



    }
}
