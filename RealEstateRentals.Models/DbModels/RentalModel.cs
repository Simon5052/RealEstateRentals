using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentals.Models.DbModels
{
    public class RentalModel
    {
        public int RentalId { get; set; }
        public int RentalUuid { get; set; }
        public int AgentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime DateDue { get; set; }

    }
}
