using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;

namespace OptimumHR.Controllers
{
    public class VacationBalanceController : Controller
    {

        private readonly AppDbContext _context;
        public VacationBalanceController(AppDbContext context)
        {
            _context = context;
        }
        // GET: VacationBalanceController
        public ActionResult Index()
        {
            var VacationBalances = from vb in _context.VacationBalances
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

            return View(VacationBalances.ToList());
        }

        // GET: VacationBalanceController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.VacationBalances.Find(id));
        }

        // GET: VacationBalanceController/Create
        public ActionResult Create(int? id)
        {
            ViewData["Rules"] = _context.VacRules.ToList();
            if (_context.Employees.Any(e => e.Id == id))
            {
                ViewData["EmployeeId"] = id;
                ViewData["EmployeeName"] = _context.Employees.Find(id)?.Name;


            }
            else if (id != null)
            {
                ModelState.AddModelError("EmployeeID", "This Employee doesn't Exist");
                /*                ViewData["EmployeeId"] = "0";*/
                return View();
            }
            return View();

        }

        // POST: VacationBalanceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationBalance balance)
        {
            ViewData["Rules"] = _context.VacRules.ToList();

            try
            {
                if (ModelState.IsValid)
                {


                    if (_context.Employees.Any(e => e.Id == balance.EmployeeId))
                    {

                        bool balanceExists = _context.VacationBalances.Any(vb => vb.EmployeeId == balance.EmployeeId && vb.Year == balance.Year);

                        if (balanceExists)
                        {
                            ModelState.AddModelError("", "A vacation balance for this employee and year already exists.");
                            return View(balance);
                        }
                        else
                        {
                            _context.VacationBalances.Add(new VacationBalance
                            {
                                Year = balance.Year,
                                DaysUsed = balance.DaysUsed,
                                EmployeeId = balance.EmployeeId,
                                VacRuleId = balance.VacRuleId,


                                AddedBy = User.Identity.Name,
                                AddedDate = DateTime.Now,
                            });
                            _context.SaveChanges();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("EmployeeID", "This Employee doesn't Exist");
                        return View(balance);
                    }
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ModelState.AddModelError("", "Invaild Input");
                    return View(balance);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong");

                return View(balance);
            }

        }

        // GET: VacationBalanceController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["Rules"] = _context.VacRules.ToList();



            return View(_context.VacationBalances.Find(id));
        }

        // POST: VacationBalanceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VacationBalance balance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VacationBalance old = _context.VacationBalances.Find(id);

                    old.VacRuleId = balance.VacRuleId;
                    old.Year = balance.Year;
                    old.DaysUsed = balance.DaysUsed;

                    _context.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "Somehing Went Wrong");
                    return View(balance);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Somehing Went Wrong");
                return View(balance);
            }
        }

        // GET: VacationBalanceController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.VacationBalances.Find(id));
        }

        // POST: VacationBalanceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VacationBalance collection)
        {
            try
            {
                collection = _context.VacationBalances.Find(id);
                _context.VacationBalances.Remove(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
