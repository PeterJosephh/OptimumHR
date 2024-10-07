using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class VacationBalance
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int DaysUsed { get; set; }


        [ForeignKey("VacRule")]
        public int VacRuleId { get; set; }
        public VacRule? VacRule { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
    }
}
