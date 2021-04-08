using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.DAL.ClientData
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
            _context.commandClient.Add(client);
            SaveChanges();
            return GetClientById(client.idClient);
        }

        public IEnumerable<Client> DeleteClient(int id)
        {
            Client c = GetClientById(id);
            _context.commandClient.Remove(c);
            SaveChanges();
            return GetAllClients();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.commandClient.ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.commandClient.FirstOrDefault(c => c.idClient == id);
        }

        private bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public Client UpdateClient(Client client)
        {
            _context.commandClient.Update(client);
            SaveChanges();
            return GetClientById(client.idClient);
        }
    }
}