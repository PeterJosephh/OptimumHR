namespace OptimumHR.ViewModel
{
    public class EmployeeProfileVM
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Acadamic_Qualification { get; set; }
        public string? Gender { get; set; }

        public string? Email { get; set; }
        public string? Nationality_ID { get; set; }

        public string? PhoneNumber { get; set; }
        public string? BankAccountNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Religion { get; set; }

        public string? Address { get; set; }

        public string? AddressLocationURL { get; set; }

        public DateTime? HireDate { get; set; }

        public int Status { get; set; } //make it Status Id *********

        public string? MilitryStatus { get; set; }

        public string? Insurance_Number { get; set; }

        public string Title { get; set; }

        public string Department { get; set; }

        public string SocialStatus { get; set; }

        public string? AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }


        public dynamic DayOffRequests { get; set; }



    }
}
