using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class TaskRequest
    {
        public int Id { get; set; }
        [Required]
        public string Manager { get; set; }
        public string Status { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public string AddedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }


    }
}
