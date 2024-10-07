using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OptimumHR.Controllers
{
    [Authorize]

    public class VariableTypeController : Controller
    {
        /*
                // GET: VariableTypesController
                public ActionResult Index()
                {
                    return View(AppDbContext.VariableTypes);
                }


                // GET: VariableTypes/Details/5
                public ActionResult Details(int id)
                {
                    return View(AppDbContext.VariableTypes.Find(t => t.Id == id));
                }

                // GET: VariableTypes/Create
                public ActionResult Create()
                {
                    return View();
                }

                // POST: VariableTypes/Create
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Create(VariableType pt)
                {
                    try
                    {
                        AppDbContext.VariableTypes.Add(new VariableType()
                        {
                            Id = AppDbContext.VariableTypes.Count + 1,
                            Type = pt.Type,
                        });

                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: VariableTypes/Edit/5
                public ActionResult Edit(int id)
                {
                    return View(AppDbContext.VariableTypes.Find(pt => pt.Id == id));
                }

                // POST: VariableTypes/Edit/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(int id, VariableType pt)
                {
                    try
                    {
                        AppDbContext.VariableTypes.Find(d => d.Id == id).Type = pt.Type;

                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }

                // GET: VariableTypes/Delete/5
                public ActionResult Delete(int id)
                {
                    return View(AppDbContext.VariableTypes.Find(d => d.Id == id));
                }

                // POST: VariableTypes/Delete/5
                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Delete(int id, VariableType t)
                {
                    try
                    {
                        AppDbContext.VariableTypes.RemoveAll(t => t.Id == id);
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }*/
    }
}
