

using System.ComponentModel.DataAnnotations;

namespace OptimumHR.Models
{
    public class SocialStatus
    {
        public int Id { get; set; }
        [Required]
        public string? Status { get; set; }
        public string? Description { get; set; }

        public string? AddedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AddedDate { get; set; }
    }
}
