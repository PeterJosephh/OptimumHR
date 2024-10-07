using System.ComponentModel.DataAnnotations;

namespace OptimumHR.Models
{
    public class DocuType
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string? Description { get; set; }

        public string? AddedBy { get; set; }

        public DateTime? AddedDate { get; set; }

        public virtual ICollection<DocumentCopy>? DocumentCopies { get; set; }



    }
}
