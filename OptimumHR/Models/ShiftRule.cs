using System.ComponentModel.DataAnnotations;

namespace OptimumHR.Models
{
    public class ShiftRule
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public TimeOnly StartTime { get; set; }
        [Required]

        public TimeOnly EndTime { get; set; }

        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual ICollection<WeeklyDayOff>? WeeklyDayOffs { get; set; }
        public virtual ICollection<Shift>? Shifts { get; set; }

    }
}
