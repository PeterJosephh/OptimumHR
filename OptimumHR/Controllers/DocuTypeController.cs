using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;

namespace OptimumHR.Controllers
{
    [Authorize]

    public class DocuTypeController : Controller
    {


        private readonly AppDbContext _context;
        public DocuTypeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DocuTypeController
        public ActionResult Index()
        {
            List<DocuType> Docs = _context.DocuTypes.ToList();

            return View(Docs);
        }

        // GET: DocuTypeController/Details/5
        public ActionResult Details(int id)
        {

            return View(_context.DocuTypes.Find(id));
        }

        // GET: DocuTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocuTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocuType docuType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.DocuTypes.Add(new DocuType()
                    {
                        Type = docuType.Type,
                        Description = docuType.Description,
                        AddedBy = User.Identity.Name,
                        AddedDate = DateTime.Now
                    });

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(docuType);
                }
            }
            catch
            {
                return View(docuType);
            }
        }

        // GET: DocuTypeController/Edit/5
        public ActionResult Edit(int id)
        {

            return View(_context.DocuTypes.Find(id));
        }

        // POST: DocuTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DocuType newDocuType)
        {
            try
            {
                _context.DocuTypes.Find(id).Type = newDocuType.Type;
                _context.DocuTypes.Find(id).Description = newDocuType.Description;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DocuTypeController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_context.DocuTypes.Find(id));
        }

        // POST: DocuTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DocuType docuType)
        {
            try
            {
                docuType = _context.DocuTypes.Find(id);
                _context.DocuTypes.Remove(docuType);
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
