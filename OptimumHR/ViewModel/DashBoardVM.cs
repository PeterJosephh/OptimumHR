using OptimumHR.Models;

namespace OptimumHR.ViewModel
{
    public class DashBoardVM
    {
        public List<ListEmplyeeVM> Employees { get; set; }
        public List<Department> Departments { get; set; }
        public dynamic DayOffRequests { get; set; }
        public dynamic permissionReqs { get; set; }
        public dynamic VacationBalances { get; set; }

    }
}
