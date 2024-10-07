using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class DayOffRequest
    {
        public int Id { get; set; }
        [Required]

        public DateOnly StartDate { get; set; }
        [Required]

        public DateOnly EndDate { get; set; }
        [Required]
        public string? Reason { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("DayOffType")]
        public int DayOffTypeId { get; set; }
        public DayOffType DayOffType { get; set; }

        [ForeignKey("RequestStatus")]
        public int RequestStatusId { get; set; }
        public RequestStatus RequestStatus { get; set; }

        public string? AddedBy { get; set; }
        public DateTime AddedDate { get; set; }

        public static string TimeText(DateTime dateTime)
        {
            TimeSpan timeSpan = DateTime.Now - dateTime;

            if (timeSpan.TotalDays > 7)
                return dateTime.ToString("yyyy-MM-dd");
            else if (timeSpan.TotalDays >= 1)
                return $"{(int)timeSpan.TotalDays} day(s) ago";
            else if (timeSpan.TotalHours >= 1)
                return $"{(int)timeSpan.TotalHours} hour(s) ago";
            else if (timeSpan.TotalMinutes >= 1)
                return $"{(int)timeSpan.TotalMinutes} minute(s) ago";
            else
                return "just now";
        }

    }
}
