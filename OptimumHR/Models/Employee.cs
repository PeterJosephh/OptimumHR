using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptimumHR.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? Acadamic_Qualification { get; set; }

        [Required]
        [StringLength(1)]
        public string? Gender { get; set; }

        [StringLength(100)]

        public string? Email { get; set; }

        [Required]
        [StringLength(14)]
        public string? Nationality_ID { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [StringLength(20)]
        public string? BankAccountNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string? Religion { get; set; }

        [StringLength(int.MaxValue)]
        public string? Address { get; set; }

        [StringLength(int.MaxValue)]
        public string? AddressLocationURL { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        [StringLength(1)]
        public int Status { get; set; } //make it Status Id *********

        [StringLength(20)]
        public string? MilitryStatus { get; set; }

        [StringLength(50)]
        public string? Insurance_Number { get; set; }

        [ForeignKey("Title")]
        public int TitleId { get; set; }
        public JobTitle? Title { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("SocialStatus")]
        public int SocialStatusId { get; set; }
        public SocialStatus? SocialStatus { get; set; }

        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }





        //---------------------------------------------------
        public virtual ICollection<TaskRequest>? TaskRequest { get; set; }
        public virtual ICollection<DayOffRequest>? DayOffRequests { get; set; }
        public virtual ICollection<DocumentCopy>? DocumentCopies { get; set; }
        public virtual ICollection<PermissionReq>? PermissionReqs { get; set; }
        public virtual ICollection<PreformanceReview>? PreformanceReviews { get; set; }
        public virtual ICollection<Shift>? Shifts { get; set; }

        public virtual ICollection<VacationBalance>? VacationBalances { get; set; }








    }
}
