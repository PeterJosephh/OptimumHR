namespace OptimumHR.ViewModel
{
    public class RequestRespondVM
    {
        public int RequestId { get; set; }
        public DateOnly RequestStart { get; set; }
        public DateOnly RequestEnd { get; set; }
        public string RequestType { get; set; }
        public string RequestReason { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public string Color { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }

    }
}
