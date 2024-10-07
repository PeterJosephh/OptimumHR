using System.ComponentModel.DataAnnotations;

namespace OptimumHR.ViewModel
{
    public class NewEmployeeFormVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

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


        public int Status { get; set; }

        [StringLength(20)]
        public string? MilitryStatus { get; set; }

        [StringLength(50)]
        public string? Insurance_Number { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]

        public int DepartmentId { get; set; }
        [Required]

        public int SocialStatusId { get; set; }





    }
}
