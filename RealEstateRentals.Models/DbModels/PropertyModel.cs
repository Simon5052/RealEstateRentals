using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentals.Models.DbModels
{
    public class PropertyModel
    {
        public int PropertyId { get; set; }
        public Guid PropertyUuid { get; set; }
        public string PropertyName { get; set; }
        public int PropertyTypeId { get; set; }
        public int LocationId { get; set; }
        public int Space { get; set; }
        public int Rooms { get; set; }
        public double Cost { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
