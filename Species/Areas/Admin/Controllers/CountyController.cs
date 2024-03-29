﻿using Microsoft.AspNetCore.Mvc;
using Species.Data.Models;
using Species.Data.Repository.IRepository;

namespace Species.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountyController : Controller
    {
        

        private readonly IUnitOfWork _unitOfWork;

        public CountyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            County county = new County();
            if (id == null)
            {
                //this is for create
                return View(county);
            }
            //this is for edit
            county = _unitOfWork.County.Get(id.GetValueOrDefault());
            if (county == null)
            {
                return NotFound();
            }
            return View(county);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(County county)
        {
            if (ModelState.IsValid)
            {
                if (county.Id == 0)
                {
                    _unitOfWork.County.Add(county);

                }
                else
                {
                    _unitOfWork.County.Update(county);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(county);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.County.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.County.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.County.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }

        #endregion
    }
}
