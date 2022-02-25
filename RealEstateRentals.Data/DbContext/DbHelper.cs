using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;
using RealEstateRentals.Data.Utilities;
using RealEstateRentals.Models.ConfigModels;
using RealEstateRentals.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RealEstateRentals.Data.DbContext
{
    public class DbHelper
    {
        public readonly Logger _logger;



        
        public string dbConnString;
        public string dbSchema;
        

        public DbHelper(Logger logger, IConfiguration configuration,IOptions<AppSettings> options)
        {
            AppSettings appSettings = options.Value;
            _logger = logger;

            dbConnString = configuration.GetConnectionString("RealEstateDb");
            dbSchema = appSettings.DbSchemas.RealEstateDbSchema;



        }


        private string GetConnectionString(IConfiguration configuration)
        {

            string dbCon = dbConnString;
            return dbCon;


        }
        private string GetDbSchema(IConfiguration configuration)
        {
            return dbSchema;
        }

        private NpgsqlConnection CreateConnection()
        {
            try
            {
                return new NpgsqlConnection(dbConnString);
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return null;
            }
        }
        private void DisposeConnection(NpgsqlConnection con)
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            catch
            {
                //Ignore exception
            }
        }

        public List<AgentModel> GetAllAgents()
        {
            List<AgentModel> allAgent = new List<AgentModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allAgent = dbCon.Query<AgentModel>("\"GetAllAgent\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<AgentModel>)allAgent;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<AgentModel>)allAgent;
            }

        }

        public string DeleteAgent(Guid agentUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteAgent\"", new
                    {
                        _agentUuid = agentUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (string)dbResponse;
            }

        }

        public string InsertAgent(string firstName, string lastName, string companyName, string email,
            string phoneNumber)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertAgent\"", new
                    {
                        _firstName = firstName,
                        _lastName = lastName,
                        _companyName = companyName,
                        _email = email,
                        _phoneNumber = phoneNumber
                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> allCustomers = new List<CustomerModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allCustomers = dbCon.Query<CustomerModel>("\"GetAllCustomer\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<CustomerModel>)allCustomers;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<CustomerModel>)allCustomers;
            }

        }

        public string DeleteCustomer(string customerUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteCustomer\"", new
                    {
                        _customerUuid = customerUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public string InsertCustomer(string firstName, string lastName, string email,
            string phoneNumber)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertCustomer\"", new
                    {
                        _firstName = firstName,
                        _lastName = lastName,
                        _email = email,
                        _phoneNumber = phoneNumber
                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<LocationModel> GetAllLocations()
        {
            List<LocationModel> allLocations = new List<LocationModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allLocations = dbCon.Query<LocationModel>("\"GetAllLocation\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<LocationModel>)allLocations;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<LocationModel>)allLocations;
            }

        }

        public string DeleteLocation(string locationUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteCustomer\"", new
                    {
                        _locationUuid = locationUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public string InsertLocation(string address, int regionId)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertLocation\"", new
                    {
                        _address = address,
                        _regionId = regionId
                        
                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<LocationModel> GetLocationByRegionUuid(Guid regionUuid)
        {
            List<LocationModel> location = new List<LocationModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    location = dbCon.Query<LocationModel>("\"GetLocationByRegionUuid\"", new { _regionUuid = regionUuid }, commandType: CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<LocationModel>)location;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (List<LocationModel>)location;
            }

        }

        //public string GetLocationByRegionUuid(Guid regionUuid)
        //{
        // return QueryFirst<string>("GetLocationByRegionUuid", new { _regionUuid = regionUuid });



        // }

        public List<PropertyModel> GetAllProperties()
        {
            List<PropertyModel> allProperties = new List<PropertyModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProperties = dbCon.Query<PropertyModel>("\"GetAllProperty\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<PropertyModel>)allProperties;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<PropertyModel>)allProperties;
            }

        }

        public string DeleteProperty(string propertyUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteProperty\"", new
                    {
                        _propertyUuid = propertyUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public string InsertProperty(string propertyName, Guid propertyTypeUuid, Guid locationUuid, int space, int rooms,
            double cost)
        {
            string dbResponse = null;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertProperty\"", new
                    {
                        _propertyName = propertyName,
                        _propertyTypeUuid = propertyTypeUuid,
                        _locationUuid = locationUuid,
                        _space = space,
                        _rooms = rooms,
                        _cost = cost,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<PropertyTypeModel> GetAllPropertyTypes()
        {
            List<PropertyTypeModel> allPropertyTypes = new List<PropertyTypeModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allPropertyTypes = dbCon.Query<PropertyTypeModel>("\"GetAllPropertyType\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<PropertyTypeModel>)allPropertyTypes;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<PropertyTypeModel>)allPropertyTypes;
            }

        }

        public string DeletePropertyType(string propertyTypeUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteProperty\"", new
                    {
                        _propertyTypeUuid = propertyTypeUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public string InsertPropertyType(string propertyTypeName)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertPropertyType\"", new
                    {
                        _propertyTypeName = propertyTypeName,
                        

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<RegionModel> GetAllRegions()
        {
            List<RegionModel> allRegions = new List<RegionModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allRegions = dbCon.Query<RegionModel>("\"GetAllRegion\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<RegionModel>)allRegions;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<RegionModel>)allRegions;
            }

        }

        public string DeleteRegion(string regionUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteRegion\"", new
                    {
                        _regionUuid = regionUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<RentalModel> GetAllRentals()
        {
            List<RentalModel> allRentals = new List<RentalModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allRentals = dbCon.Query<RentalModel>("\"GetAllRental\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<RentalModel>)allRentals;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<RentalModel>)allRentals;
            }

        }

        public string DeleteRental(string rentalUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteRental\"", new
                    {
                        _rentalUuid = rentalUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public string InsertRental(int agentId, int customerId, DateTime dateRented, DateTime dateDue)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertRental\"", new
                    {
                        _agentId = agentId,
                        _customerId = customerId,
                        _dateRented = dateRented,
                        _dateDue = dateDue


                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<PropertyModel> GetRecentProperties()
        {
            List<PropertyModel> getRecentProperties = new List<PropertyModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    getRecentProperties = dbCon.Query<PropertyModel>($"{dbSchema}.\"GetRecentProperty\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<PropertyModel>)getRecentProperties;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<PropertyModel>)getRecentProperties;
            }

        }

        public List<PropertyTypeModel> GetPropertyTypeByUuid(Guid propertyTypeUuid)
        {
            List<PropertyTypeModel> location = new List<PropertyTypeModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    location = dbCon.Query<PropertyTypeModel>("\"GetPropertyTypeByUuid\"", new { _propertyTypeUuid = propertyTypeUuid }, commandType: CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<PropertyTypeModel>)location;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (List<PropertyTypeModel>)location;
            }

        }

        public string UpdateAgent(Guid agentUuid, string firstName, string lastName, string companyName, string email,
            string phoneNumber)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"UpdateAgent\"", new
                    {
                        _agentUuid = agentUuid,
                        _firstName = firstName,
                        _lastName = lastName,
                        _companyName = companyName,
                        _email = email,
                        _phoneNumber = phoneNumber


                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }



    }
}
