using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlantRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        
        public PlantRequestController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            PlantRequest plantRequest = new PlantRequest();
            if (id == null)
            {
                //this is for create
                return View(plantRequest);
            }
            //this is for edit
            plantRequest = _unitOfWork.PlantRequest.Get(id.GetValueOrDefault());
            if (plantRequest == null)
            {
                return NotFound();
            }
            return View(plantRequest);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PlantRequest plantRequest)
        {
            if (ModelState.IsValid)
            {
                if (plantRequest.Id == 0)
                {
                    _unitOfWork.PlantRequest.Add(plantRequest);

                }
                else
                {
                    _unitOfWork.PlantRequest.Update(plantRequest);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(plantRequest);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.PlantRequest.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.PlantRequest.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.PlantRequest.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
