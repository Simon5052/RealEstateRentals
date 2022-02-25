using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentals.Models.DbModels
{
    public class PropertyTypeModel
    {
        public int PropertyTypeId { get; set; }
        public Guid PropertyTypeUuid { get; set; }
        public string PropertTypeName { get; set; }

    }
}
