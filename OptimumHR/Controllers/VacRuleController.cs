using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;

namespace OptimumHR.Controllers
{
    public class VacRuleController : Controller
    {
        private readonly AppDbContext _context;
        public VacRuleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VacRuleController
        public ActionResult Index()
        {

            return View(_context.VacRules.ToList());
        }

        // GET: VacRuleController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.VacRules.Find(id));
        }

        // GET: VacRuleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacRuleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacRule rule)
        {
            try
            {
                _context.VacRules.Add(new VacRule()
                {
                    Name = rule.Name,
                    TotalDays = rule.TotalDays,

                    AddedBy = User.Identity.Name,
                    AddedDate = DateTime.Now,

                });

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VacRuleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_context.VacRules.Find(id));
        }

        // POST: VacRuleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VacRule rule)
        {

            try
            {
                VacRule newRule = _context.VacRules.Find(id);
                newRule.Name = rule.Name;
                newRule.TotalDays = rule.TotalDays;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VacRuleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_context.VacRules.Find(id));
        }

        // POST: VacRuleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, VacRule rule)
        {
            try
            {

                rule = _context.VacRules.Find(id);
                _context.VacRules.Remove(rule);
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
