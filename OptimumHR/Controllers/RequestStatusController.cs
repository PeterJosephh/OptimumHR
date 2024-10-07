using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;

namespace OptimumHR.Controllers
{
    [Authorize]

    public class RequestStatusController : Controller
    {

        private readonly AppDbContext _context;
        public RequestStatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RequestStatusController
        public ActionResult Index()
        {

            return View(_context.RequestStatuses.ToList());
        }

        // GET: RequestStatusController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.RequestStatuses.Find(id));
        }

        // GET: RequestStatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestStatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestStatus status)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.RequestStatuses.Add(new RequestStatus()
                    {
                        Name = status.Name,
                        Description = status.Description,
                        Color = status.Color,
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

        // GET: RequestStatusController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.RequestStatuses.Find(id));
        }

        // POST: RequestStatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequestStatus newRequestStatus)
        {
            try
            {
                RequestStatus old = _context.RequestStatuses.Find(id);
                old.Name = newRequestStatus.Name;
                old.Description = newRequestStatus.Description;
                old.Color = newRequestStatus.Color;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RequestStatusController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.RequestStatuses.Find(id));
        }

        // POST: RequestStatusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, RequestStatus status)
        {
            try
            {
                status = _context.RequestStatuses.Find(id);
                _context.RequestStatuses.Remove(status);
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
