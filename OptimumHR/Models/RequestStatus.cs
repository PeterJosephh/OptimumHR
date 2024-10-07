using System.ComponentModel.DataAnnotations;

namespace OptimumHR.Models
{
    public class RequestStatus
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Color { get; set; }

        public string? AddedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }

        public virtual ICollection<DayOffRequest>? DayOffRequests { get; set; }
        public virtual ICollection<PermissionReq>? PermissionReqs { get; set; }

    }
}
