using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;
using OptimumHR.ViewModel;

namespace OptimumHR.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;
        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            List<Department> deps = _context.Departments.ToList();

            return View(deps);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            ViewData["Employee"] = (from emp in _context.Employees
                                    join dep in _context.DayOffTypes
                                    on emp.DepartmentId equals dep.Id
                                    join title in _context.JobTitles
                                    on emp.TitleId equals title.Id

                                    where emp.DepartmentId == id
                                    select new ListEmplyeeVM()
                                    {
                                        Id = emp.Id,
                                        Name = emp.Name,
                                        Gender = emp.Gender,
                                        Status = emp.Status,
                                        Title = emp.Title.Name,
                                        TitleId = emp.TitleId,

                                        AddedBy = emp.AddedBy,
                                        AddedDate = emp.AddedDate,

                                    }).ToList();

            return View(_context.Departments.Find(id));

        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDepVM dep)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Departments.Add(new Department()
                    {
                        Name = dep.Name,
                        Description = dep.Description,
                        AddedBy = User.Identity.Name,
                        AddedDate = DateTime.Now
                    });

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(dep);

                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.Departments.Find(id));
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department newDepartment)
        {
            try
            {
                _context.Departments.Find(id).Name = newDepartment.Name;
                _context.Departments.Find(id).Description = newDepartment.Description;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.Departments.Find(id));
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Department dep)
        {
            try
            {
                dep = _context.Departments.Find(id);
                _context.Departments.Remove(dep);
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
