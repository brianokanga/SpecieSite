using Microsoft.AspNetCore.Mvc;
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
    }
}
