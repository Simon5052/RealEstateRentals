using Microsoft.AspNetCore.Mvc;
using RealEstateRentals.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentals.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DbHelper _dbHelper;
        public CustomerController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;

        }
        public IActionResult AllCustomer()
        {
            ViewBag.Customers = _dbHelper.GetAllCustomers();

            return View();
        }
    }
}
