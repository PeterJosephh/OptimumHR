using System.ComponentModel.DataAnnotations;

namespace OptimumHR.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }

        public string? AddedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? AddedDate { get; set; }
    }
}
