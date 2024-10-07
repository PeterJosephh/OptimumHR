using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;
using OptimumHR.ViewModel;


namespace OptimumHR.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly AppDbContext _context;
        public DashBoardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DashBoardVM dashBoardVM = new DashBoardVM();
            dashBoardVM.Employees = (from emp in _context.Employees
                                     join dep in _context.Departments
                                     on emp.DepartmentId equals dep.Id
                                     join title in _context.JobTitles
                                     on emp.TitleId equals title.Id

                                     select new ListEmplyeeVM()
                                     {
                                         Id = emp.Id,
                                         Name = emp.Name,
                                         Gender = emp.Gender,
                                         Status = emp.Status,
                                         Title = title.Name,
                                         TitleId = title.Id,

                                         Department = dep.Name,
                                         DepartmentId = dep.Id,

                                         AddedBy = emp.AddedBy,
                                         AddedDate = emp.AddedDate,

                                     }).ToList();

            dashBoardVM.Departments = _context.Departments.ToList();

            var DayOffRequests = from Req in _context.DayOffRequests
                                 join Type in _context.DayOffTypes
                                 on Req.DayOffTypeId equals Type.Id
                                 join emp in _context.Employees
                                 on Req.EmployeeId equals emp.Id
                                 join stat in _context.RequestStatuses
                                 on Req.RequestStatusId equals stat.Id

                                 select new
                                 {
                                     RequestId = Req.Id,
                                     RequestDAte = Req.StartDate,
                                     RequestType = Type.Name,
                                     RequestReason = Req.Reason,
                                     EmployeeName = emp.Name,
                                     RequestAddedDate = DayOffRequest.TimeText(Req.AddedDate),

                                     Color = stat.Color,
                                     StatusName = stat.Name,
                                     RequestDes = Type.Description,

                                 };

            dashBoardVM.DayOffRequests = DayOffRequests.ToList();
            var permissionReqs = (from req in _context.PermissionReqs
                                  join emp in _context.Employees
                                  on req.EmployeeId equals emp.Id
                                  join stat in _context.RequestStatuses
                                  on req.StatusId equals stat.Id


                                  select new
                                  {
                                      EmployeeId = emp.Id,
                                      EmployeeName = emp.Name,
                                      RequestId = req.Id,
                                      RequestStatus = stat.Name,
                                      RequestColor = stat.Color,
                                      Date = req.Date,
                                      From = req.StartTime,
                                      To = req.EndTime,

                                  });
            dashBoardVM.permissionReqs = permissionReqs.ToList();


            dashBoardVM.VacationBalances = from vb in _context.VacationBalances
                                           join vr in _context.VacRules
                                           on vb.VacRuleId equals vr.Id
                                           join emp in _context.Employees
                                           on vb.EmployeeId equals emp.Id

                                           select new
                                           {
                                               Year = vb.Year,
                                               DaysUsed = vb.DaysUsed,
                                               Remain = vr.TotalDays - vb.DaysUsed,
                                               TotalDays = vr.TotalDays,
                                               RuleName = vr.Name,
                                               RuleId = vr.Id,

                                               EmployeeName = emp.Name,
                                               EmployeeId = emp.Id,
                                               AddedBy = vb.AddedBy,
                                               AddedDate = vb.AddedDate,
                                               Id = vb.Id,



                                           };


            return View(dashBoardVM);
        }

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
