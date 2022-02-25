using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentals.Models.DbModels
{
    public class AgentModel
    {
        public int AgentId { get; set; }
        public Guid AgentUuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
