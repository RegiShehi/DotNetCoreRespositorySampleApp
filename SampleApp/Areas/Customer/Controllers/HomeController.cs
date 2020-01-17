using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.DataAccess.Data.Repository.IRepository;
using SampleApp.Extensions;
using SampleApp.Models.ViewModels;
using SampleApp.Utility;

namespace SampleApp.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public HomeViewModel HomeVM { get; set; }

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Details(int id)
        {
            var serviceFromDB = _unitOfWork.Service.GetFirstOrDefault(includeProperties: "Category", filter: c => c.Id == id);

            return View(serviceFromDB);
        }

        public IActionResult AddToCart(int serviceId)
        {
            List<int> sessionList = new List<int>();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SD.SessionCart)))
            {
                sessionList.Add(serviceId);

                HttpContext.Session.SetObject(SD.SessionCart, sessionList);
            }
            else
            {
                sessionList = HttpContext.Session.GetObject<List<int>>(SD.SessionCart);

                if (!sessionList.Contains(serviceId))
                {
                    sessionList.Add(serviceId);
                    HttpContext.Session.SetObject(SD.SessionCart, sessionList);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            HomeVM = new HomeViewModel()
            {
                CategoryList = _unitOfWork.Category.GetAll(),
                ServiceList = _unitOfWork.Service.GetAll()
            };

            return View(HomeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
