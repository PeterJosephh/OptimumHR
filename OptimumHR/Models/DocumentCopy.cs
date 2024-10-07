using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class DocumentCopy
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("DocuType")]
        public int DocuTypeId { get; set; }
        public DocuType DocuType { get; set; }
        [Required]
        public string DocumentURL { get; set; }
        [Required]
        public string DocumentName { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public string AddedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }

    }
}
