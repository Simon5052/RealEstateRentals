using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentals.Models.InputModels
{
    public class AddProperty
    {
        
        public string PropertyName { get; set; }
        public Guid PropertyTypeId { get; set; }
        public Guid RegionId { get; set; }
        public Guid LocationId { get; set; }
       
        public int Space { get; set; }
        public int Rooms { get; set; }
        public double Cost { get; set; }

    }
}
