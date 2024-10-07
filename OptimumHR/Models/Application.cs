using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Status { get; set; }

        [ForeignKey("JobRecruitment")]
        public int JobRecruitmentId { get; set; }
        public JobRecruitment JobRecruitment { get; set; }


        public string AddedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }
    }
}
