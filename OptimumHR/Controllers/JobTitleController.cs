using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;

namespace OptimumHR.Controllers
{
    [Authorize]
    public class JobTitleController : Controller
    {

        private readonly AppDbContext _context;
        public JobTitleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: JobTitleController
        public ActionResult Index()
        {

            return View(_context.JobTitles.ToList());
        }

        // GET: JobTitleController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.JobTitles.Find(id));
        }

        // GET: JobTitleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobTitleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobTitle title)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.JobTitles.Add(new JobTitle()
                    {
                        Name = title.Name,
                        Description = title.Description,
                        AddedBy = User.Identity.Name,
                        AddedDate = DateTime.Now
                    });

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: JobTitleController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.JobTitles.Find(id));
        }

        // POST: JobTitleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobTitle newJobTitle)
        {
            try
            {
                _context.JobTitles.Find(id).Name = newJobTitle.Name;
                _context.JobTitles.Find(id).Description = newJobTitle.Description;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobTitleController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.JobTitles.Find(id));
        }

        // POST: JobTitleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, JobTitle title)
        {
            try
            {
                title = _context.JobTitles.Find(id);
                _context.JobTitles.Remove(title);
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
