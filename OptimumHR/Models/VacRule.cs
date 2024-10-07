namespace OptimumHR.Models
{
    public class VacRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalDays { get; set; }
        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }

        public virtual ICollection<VacationBalance>? VacationBalances { get; set; }

    }
}
