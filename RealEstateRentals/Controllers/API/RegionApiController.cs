﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentals.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentals.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionApiController : ControllerBase
    {
        public readonly DbHelper _dbHelper;
        public RegionApiController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        [Route("GetAllRegions")]

        public IActionResult GetAllRegions()
        {
            var regions = _dbHelper.GetAllRegions();
            return Ok(regions);
        }

        
    }

   
    
   
}
