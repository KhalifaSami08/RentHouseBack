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

        public void CreateClient(Client client)
        {
            _context.CommandClient.Add(client);
            SaveChanges();
        }

        public void DeleteClient(int id)
        {
            Client c = GetClientById(id);
            _context.CommandClient.Remove(c);
            SaveChanges();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.CommandClient.ToList();
        }

        public Client GetClientById(int id)
        {
            return _context.CommandClient.FirstOrDefault(c => c.IdClient == id);
        }

        private void SaveChanges()
        { 
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.CommandClient.Update(client);
            SaveChanges();
        }
    }
}