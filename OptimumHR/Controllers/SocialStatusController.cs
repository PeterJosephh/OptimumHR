using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;

namespace OptimumHR.Controllers
{
    [Authorize]

    public class SocialStatusController : Controller
    {

        private readonly AppDbContext _context;
        public SocialStatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SocialStatusController
        public ActionResult Index()
        {

            return View(_context.SocialStatuses.ToList());
        }

        // GET: SocialStatusController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.SocialStatuses.Find(id));
        }

        // GET: SocialStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialStatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SocialStatus title)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.SocialStatuses.Add(new SocialStatus()
                    {
                        Status = title.Status,
                        Description = title.Description,
                        AddedBy = User.Identity.Name,
                        AddedDate = DateTime.Now
                    });

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Create));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialStatusController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.SocialStatuses.Find(id));
        }

        // POST: SocialStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SocialStatus newSocialStatus)
        {
            try
            {
                _context.SocialStatuses.Find(id).Status = newSocialStatus.Status;
                _context.SocialStatuses.Find(id).Description = newSocialStatus.Description;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SocialStatusController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.SocialStatuses.Find(id));
        }

        // POST: SocialStatusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SocialStatus status)
        {
            try
            {
                status = _context.SocialStatuses.Find(id);
                _context.SocialStatuses.Remove(status);
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
