using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;

namespace OptimumHR.Controllers
{
    public class PermissionReqController : Controller
    {
        private readonly AppDbContext _context;
        public PermissionReqController(AppDbContext context)
        {
            _context = context;
        }
        // GET: PermissionReqController
        public ActionResult Index()
        {
            var list = (from req in _context.PermissionReqs
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

                        }).ToList();

            return View(list);
        }

        // GET: PermissionReqController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PermissionReqController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PermissionReqController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PermissionReq req)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.PermissionReqs.Add(new PermissionReq()
                    {
                        Date = req.Date,
                        StartTime = req.StartTime,
                        EndTime = req.EndTime,
                        Description = req.Description,

                        EmployeeId = 2,
                        StatusId = 3,

                        AddedBy = User.Identity.Name,
                        AddedDate = DateTime.Now,


                    });
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(req);

                }

            }
            catch
            {
                return View(req);
            }
        }

        // GET: PermissionReqController/Edit/5
        public ActionResult Respond(int id)
        {
            ViewData["RequestStatus"] = _context.RequestStatuses.ToList();


            var PermissionRespond = (from Per in _context.PermissionReqs
                                     join emp in _context.Employees
                                     on Per.EmployeeId equals emp.Id
                                     join stat in _context.RequestStatuses
                                     on Per.StatusId equals stat.Id
                                     where Per.Id == id

                                     select new
                                     {
                                         Id = id,
                                         PerDate = Per.Date,
                                         PerStart = Per.StartTime,
                                         PerEnd = Per.EndTime,

                                         EmployeeName = emp.Name,
                                         EmployeeId = emp.Id,

                                         Color = stat.Color,
                                         StatusName = stat.Name,
                                         StatusId = stat.Id,

                                         AddedBy = Per.AddedBy,
                                         AddedDate = Per.AddedDate

                                     }).FirstOrDefault();

            return View(PermissionRespond);
        }

        // POST: PermissionReqController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Respond(int id, int StatusId)
        {
            try
            {
                _context.PermissionReqs.Find(id).StatusId = StatusId;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PermissionReqController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PermissionReqController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
