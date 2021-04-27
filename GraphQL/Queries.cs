using System;
using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.DAL.ClientData;
using Backend_RentHouse_Khalifa_Sami.DAL.ContractData;
using Backend_RentHouse_Khalifa_Sami.DAL.PropertyData;
using Backend_RentHouse_Khalifa_Sami.Model;
using HotChocolate;
using HotChocolate.Data;

namespace Backend_RentHouse_Khalifa_Sami.GraphQL
{
    public class Queries
    {
        [UseProjection]
        public IEnumerable<Contract> GetContracts([Service] SqlContractRepo contractRepo)
        {
            return contractRepo.GetAllContracts();
        }
        
        public IEnumerable<Property> GetProperties([Service] SqlPropertyRepo propertyRepo)
        {
            Console.Write("Properties");
            return propertyRepo.GetAllProperties();
        }
        
        public IEnumerable<Client> GetClients([Service] SqlClientRepo clientRepo)
        {
            return clientRepo.GetAllClients();
        }
        
    }
}