using Microsoft.AspNetCore.Mvc;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;
using OptimumHR.ViewModel;

namespace OptimumHR.Controllers
{
    public class DayOffRequestController : Controller
    {
        private readonly AppDbContext _context;
        public DayOffRequestController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var RequestWithTypeAndEmloyee = from Req in _context.DayOffRequests
                                            join Type in _context.DayOffTypes
                                            on Req.DayOffTypeId equals Type.Id
                                            join emp in _context.Employees
                                            on Req.EmployeeId equals emp.Id
                                            join stat in _context.RequestStatuses
                                            on Req.RequestStatusId equals stat.Id

                                            select new
                                            {
                                                RequestId = Req.Id,
                                                RequestDAte = Req.StartDate,
                                                RequestType = Type.Name,
                                                RequestReason = Req.Reason,
                                                EmployeeName = emp.Name,
                                                RequestAddedDate = DayOffRequest.TimeText(Req.AddedDate),

                                                Color = stat.Color,
                                                StatusName = stat.Name,
                                                RequestDes = Type.Description,

                                            };

            return View(RequestWithTypeAndEmloyee.ToList());
        }


        public IActionResult Create()
        {
            ViewData["DayOffTypes"] = _context.DayOffTypes.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(DayOffReqVM DayOffReq)
        {
            if (ModelState.IsValid)
            {
                _context.DayOffRequests.Add(new DayOffRequest()
                {
                    DayOffTypeId = DayOffReq.DayOffTypeId,
                    StartDate = DayOffReq.StartDate,
                    EndDate = DayOffReq.EndDate,
                    Reason = DayOffReq.Reason,
                    AddedBy = User.Identity.Name,
                    AddedDate = DateTime.Now,


                    EmployeeId = 2, //Will Add Signd In Employee ID
                    RequestStatusId = 3, //Pending
                });
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(DayOffReq);
            }

        }


        public ActionResult Edit(int id)
        {

            ViewData["RequestStatus"] = _context.RequestStatuses.ToList();


            RequestRespondVM? RequestRespondVM = (from Req in _context.DayOffRequests
                                                  join Type in _context.DayOffTypes
                                                  on Req.DayOffTypeId equals Type.Id
                                                  join emp in _context.Employees
                                                  on Req.EmployeeId equals emp.Id
                                                  join stat in _context.RequestStatuses
                                                  on Req.RequestStatusId equals stat.Id
                                                  where Req.Id == id

                                                  select new RequestRespondVM()
                                                  {
                                                      RequestId = Req.Id,
                                                      RequestStart = Req.StartDate,
                                                      RequestEnd = Req.EndDate,
                                                      RequestType = Type.Name,
                                                      RequestReason = Req.Reason,
                                                      EmployeeName = emp.Name,
                                                      EmployeeId = emp.Id,

                                                      Color = stat.Color,
                                                      StatusName = stat.Name,
                                                      StatusId = stat.Id

                                                  }).FirstOrDefault();

            return View(RequestRespondVM);
        }

        // POST: DayOffREqController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequestRespondVM RequestRespondVM)
        {
            try
            {
                _context.DayOffRequests.Find(id).RequestStatusId = RequestRespondVM.StatusId;
                _context.DayOffRequests.Find(id).Reason = RequestRespondVM.RequestReason;

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
