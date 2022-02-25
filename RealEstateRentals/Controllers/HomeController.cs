using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateRentals.Data.DbContext;
using RealEstateRentals.Data.Utilities;
using RealEstateRentals.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentals.Controllers
{
    public class HomeController : Controller
    {
        private readonly Logger _logger;
        public readonly DbHelper _dbHelper;

        public HomeController(Logger logger, DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.RecentProperties = _dbHelper.GetRecentProperties();
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
