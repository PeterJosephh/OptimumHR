using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;
using OptimumHR.ViewModel;

namespace OptimumHR.Controllers
{
    public class DayOffTypeController : Controller
    {
        private readonly AppDbContext _context;
        public DayOffTypeController(AppDbContext context)
        {
            _context = context;
        }
        // GET: DayOffTypeController
        public ActionResult Index()
        {
            List<DayOffType> deps = _context.DayOffTypes.ToList();

            return View(deps);
        }

        // GET: DayOffTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View(_context.DayOffTypes.Find(id));
        }

        // GET: DayOffTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DayOffTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTypeVM collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.DayOffTypes.Add(new DayOffType()
                    {
                        Name = collection.Name,
                        Description = collection.Description,
                        AddedBy = User.Identity.Name,
                        AddedDate = DateTime.Now,

                    });
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                return RedirectToAction(nameof(Create));

            }
            catch
            {
                return View();
            }
        }

        // GET: DayOffTypeController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.DayOffTypes.Find(id));
        }

        // POST: DayOffTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateTypeVM newDayOffType)
        {
            try
            {
                _context.DayOffTypes.Find(id).Name = newDayOffType.Name;
                _context.DayOffTypes.Find(id).Description = newDayOffType.Description;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DayOffTypeController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.DayOffTypes.Find(id));
        }

        // POST: DayOffTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DayOffType docuType)
        {
            try
            {
                docuType = _context.DayOffTypes.Find(id);
                _context.DayOffTypes.Remove(docuType);
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
