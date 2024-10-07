using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class WeeklyDayOff
    {
        public int Id { get; set; }

        [Required]
        public string DayOfWeek { get; set; }


        [ForeignKey("ShiftRule")]
        public int ShiftRuleId { get; set; }
        public ShiftRule ShiftRule { get; set; }



        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
