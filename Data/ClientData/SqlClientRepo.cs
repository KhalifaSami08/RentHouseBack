using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Data.ClientData
{
    public class SqlClientRepo : IClientRepo
    {

        private readonly MyDbContext _context;

        public SqlClientRepo(MyDbContext context)
        {
            _context = context;
        }

        public Client CreateClient(Client client)
        {
            _context.CommandClient.Add(client);
            SaveChanges();
            return GetClientById(client.idClient);
        }

        public IEnumerable<Client> DeleteClient(int id)
        {
            Client c = GetClientById(id);
            _context.CommandClient.Remove(c);
            SaveChanges();
            return GetAllClients();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.CommandClient.ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.CommandClient.FirstOrDefault(c => c.idClient == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Client UpdateClient(Client client)
        {
            _context.CommandClient.Update(client);
            SaveChanges();
            return GetClientById(client.idClient);
        }
    }
}