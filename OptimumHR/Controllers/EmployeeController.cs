using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;
using OptimumHR.ViewModel;

namespace OptimumHR.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<ListEmplyeeVM> employees = (from emp in _context.Employees
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
            return View(employees);
        }


        public async Task<IActionResult> Profile(int id)
        {
            var employeeProfileVM = await (from emp in _context.Employees
                                           where emp.Id == id
                                           select new EmployeeProfileVM
                                           {
                                               Id = emp.Id,
                                               Name = emp.Name,
                                               Acadamic_Qualification = emp.Acadamic_Qualification,
                                               Gender = emp.Gender,
                                               Email = emp.Email,
                                               Nationality_ID = emp.Nationality_ID,
                                               PhoneNumber = emp.PhoneNumber,
                                               BankAccountNumber = emp.BankAccountNumber,
                                               DateOfBirth = emp.DateOfBirth,
                                               Religion = emp.Religion,
                                               Address = emp.Address,
                                               AddressLocationURL = emp.AddressLocationURL,
                                               HireDate = emp.HireDate,
                                               Status = emp.Status,
                                               MilitryStatus = emp.MilitryStatus,
                                               Insurance_Number = emp.Insurance_Number,
                                               Title = emp.Title.Name,
                                               Department = emp.Department.Name,
                                               SocialStatus = emp.SocialStatus.Status,
                                               AddedBy = emp.AddedBy,
                                               AddedDate = emp.AddedDate,
                                               DayOffRequests = emp.DayOffRequests.Select(req => new
                                               {
                                                   RequestId = req.Id,
                                                   RequestDAte = req.StartDate,
                                                   RequestType = req.DayOffType.Name,
                                                   RequestReason = req.Reason,
                                                   EmployeeName = req.Employee.Name,
                                                   Color = req.RequestStatus.Color,
                                                   StatusName = req.RequestStatus.Name,
                                                   RequestDes = req.DayOffType.Description,
                                               }).ToList()
                                           }).FirstOrDefaultAsync();

            return View(employeeProfileVM);
        }



        [HttpGet]
        public IActionResult Create()
        {

            ViewData["Departments"] = _context.Departments.ToList();
            ViewData["SocialStatus"] = _context.SocialStatuses.ToList();
            ViewData["Titles"] = _context.JobTitles.ToList();



            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(NewEmployeeFormVM newEmployee)
        {
            ViewData["Departments"] = _context.Departments.ToList();
            ViewData["SocialStatus"] = _context.SocialStatuses.ToList();
            ViewData["Titles"] = _context.JobTitles.ToList();


            if (ModelState.IsValid)
            {
                _context.Employees.Add(new Employee()
                {
                    Name = newEmployee.Name,
                    Nationality_ID = newEmployee.Nationality_ID,
                    Gender = newEmployee.Gender,
                    Religion = newEmployee.Religion,
                    PhoneNumber = newEmployee.PhoneNumber,
                    Email = newEmployee.Email,
                    SocialStatusId = (int)newEmployee.SocialStatusId,
                    DepartmentId = (int)newEmployee.DepartmentId,
                    DateOfBirth = newEmployee.DateOfBirth,
                    Acadamic_Qualification = newEmployee.Acadamic_Qualification,
                    MilitryStatus = newEmployee.MilitryStatus,
                    Address = newEmployee.Address,
                    AddressLocationURL = newEmployee.AddressLocationURL,
                    TitleId = newEmployee.TitleId,
                    HireDate = newEmployee.HireDate,
                    Insurance_Number = newEmployee.Insurance_Number,
                    BankAccountNumber = newEmployee.BankAccountNumber,


                    Status = 1,
                    AddedBy = User.Identity.Name,
                    AddedDate = DateTime.Now,



                });
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(newEmployee);

            }

        }


        public ActionResult Edit(int id)
        {
            ViewData["Departments"] = _context.Departments.ToList();
            ViewData["SocialStatus"] = _context.SocialStatuses.ToList();
            ViewData["Titles"] = _context.JobTitles.ToList();

            return View(_context.Employees.Find(id));
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NewEmployeeFormVM newEmployee)
        {
            try
            {
                Employee oldEmployee = _context.Employees.Find(id);

                oldEmployee.Name = newEmployee.Name;
                oldEmployee.Nationality_ID = newEmployee.Nationality_ID;
                oldEmployee.Gender = newEmployee.Gender;
                oldEmployee.Religion = newEmployee.Religion;
                oldEmployee.PhoneNumber = newEmployee.PhoneNumber;
                oldEmployee.Email = newEmployee.Email;
                oldEmployee.SocialStatusId = (int)newEmployee.SocialStatusId;
                oldEmployee.DepartmentId = (int)newEmployee.DepartmentId;
                oldEmployee.DateOfBirth = newEmployee.DateOfBirth;
                oldEmployee.Acadamic_Qualification = newEmployee.Acadamic_Qualification;
                oldEmployee.MilitryStatus = newEmployee.MilitryStatus;
                oldEmployee.Address = newEmployee.Address;
                oldEmployee.AddressLocationURL = newEmployee.AddressLocationURL;
                oldEmployee.TitleId = newEmployee.TitleId;
                oldEmployee.HireDate = newEmployee.HireDate;
                oldEmployee.Insurance_Number = newEmployee.Insurance_Number;
                oldEmployee.BankAccountNumber = newEmployee.BankAccountNumber;

                oldEmployee.Status = newEmployee.Status;


                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
