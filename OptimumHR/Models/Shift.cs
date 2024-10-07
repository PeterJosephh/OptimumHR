using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class Shift
    {
        public int Id { get; set; }

        [ForeignKey("ShiftRuleId")]
        public int ShiftRuleId { get; set; }
        public ShiftRule ShiftRule { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }


    }
}
