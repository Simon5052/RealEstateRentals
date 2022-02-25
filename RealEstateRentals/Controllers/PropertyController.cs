using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentals.Data.DbContext;
using RealEstateRentals.Models.DbModels;
using RealEstateRentals.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentals.Controllers
{
    public class PropertyController : Controller
    {
        public readonly DbHelper _dbHelper;
        public PropertyController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;

        }

        public IActionResult All()
        {
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProperty addProperty)
        {

            var dbResponse = _dbHelper.InsertProperty(addProperty.PropertyName,addProperty.PropertyTypeId,addProperty.LocationId,
                addProperty.Space, addProperty.Rooms, addProperty.Cost);

            if (dbResponse == string.Empty)
                return RedirectToAction(nameof(All));

            return View(addProperty);



        }


        [HttpPost]
        public IActionResult Property_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _dbHelper.GetAllProperties();
            
            data = data.OrderByDescending(d => d.CreatedAt).ToList();

            return Json(data.ToDataSourceResult(request));
        }

       

    }
}
