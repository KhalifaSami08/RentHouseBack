using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.DAL.ClientData
{
    public interface IClientRepo
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void CreateClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int id);
    }
}