using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Species.Data.Models;
using Species.Data.Repository.IRepository;
using Species.ViewModels;


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
            PlantRequestViewModel plantRequestViewModel = new PlantRequestViewModel()
            {
                PlantRequest = new PlantRequest(),
                CountyList = _unitOfWork.County.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                SubCountyList = _unitOfWork.SubCounty.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                LocationList = _unitOfWork.Location.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                SpecieList = _unitOfWork.Specie.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };
            if (id == null)
            {
                //this is for create
                return View(plantRequestViewModel);
            }
            //this is for edit
            plantRequestViewModel.PlantRequest = _unitOfWork.PlantRequest.Get(id.GetValueOrDefault());
            if (plantRequestViewModel.PlantRequest == null)
            {
                return NotFound();
            }
            return View(plantRequestViewModel);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Upsert(PlantRequest plantRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (plantRequest.Id == 0)
        //        {
        //            _unitOfWork.PlantRequest.Add(plantRequest);

        //        }
        //        else
        //        {
        //            _unitOfWork.PlantRequest.Update(plantRequest);
        //        }
        //        _unitOfWork.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(plantRequest);
        //}


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.PlantRequest.GetAll(includeProperties:"County, SubCounty, Location, Specie");
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
