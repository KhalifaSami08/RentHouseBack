using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Model.Client;

namespace Backend_RentHouse_Khalifa_Sami.Data.ClientData
{
    public interface IClientRepo
    {
        bool SaveChanges();
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        Client CreateClient(Client client);
        Client UpdateClient(Client client);
        IEnumerable<Client> DeleteClient(int id);
    }
}