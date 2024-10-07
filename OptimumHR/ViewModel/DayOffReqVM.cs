using System.ComponentModel.DataAnnotations;

namespace OptimumHR.ViewModel
{
    public class DayOffReqVM
    {
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]

        public DateOnly EndDate { get; set; }
        [Required]

        public string Reason { get; set; }
        [Required]

        public int DayOffTypeId { get; set; }

    }
}
