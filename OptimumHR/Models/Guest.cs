using System.ComponentModel.DataAnnotations;

namespace OptimumHR.Models
{
    public class Guest
    {
        public int Id { get; set; }
        [Required]

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(14)]
        public string? Nationality_ID { get; set; }
        public string Email { get; set; }
        public string? ResumeFileURL { get; set; }

        public virtual ICollection<Application> Applications { get; set; }


        public string AddedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime AddedDate { get; set; }


        public string Username { get; set; }
        public string Password { get; set; }




    }
}
