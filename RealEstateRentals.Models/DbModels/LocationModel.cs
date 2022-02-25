using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentals.Models.DbModels
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public Guid LocationUuid { get; set; }
        public string Address { get; set; }
        public int RegionId { get; set; }
        public Guid RegionUuid { get; set; }

    }
}
