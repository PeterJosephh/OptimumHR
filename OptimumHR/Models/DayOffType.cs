namespace OptimumHR.Models
{
    public class DayOffType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual ICollection<DocumentCopy>? DocumentCopies { get; set; }

    }
}
