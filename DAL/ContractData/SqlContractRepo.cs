using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend_RentHouse_Khalifa_Sami.DAL.ContractData
{
    public class SqlContractRepo : IContractRepo
    {
        private readonly MyDbContext _context;
        public SqlContractRepo(MyDbContext context)
        {
            _context = context;
        }
        public Contract CreateContract(Contract contract)
        {
            _context.CommandContract.Add(contract);
            SaveChanges();
            return contract;
        }
        public IEnumerable<Contract> DeleteContract(int id)
        {
            if (GetContractById(id) == null) return GetAllContracts();
            _context.CommandContract.Remove(GetContractById(id));
            SaveChanges();
            return GetAllContracts();
        }
        public IEnumerable<Contract> GetAllContracts()
        {
            return _context.CommandContract
                .Include(p => p.Client)
                .Include(p => p.Property)
                .ToList();
        }

        public Contract GetContractById(int id)
        {
            return _context.CommandContract
                .Include(p => p.Client)
                .Include(p => p.Property)
                .FirstOrDefault(c => c.IdContract == id);
        }
        public Contract GetClientContractById(int id)
        {
            return _context.CommandContract.FirstOrDefault(c => c.ClientId == id);
        }
        private void SaveChanges()
        {
            _context.SaveChanges();
        }
        public Contract UpdateContract(Contract contract)
        {
            _context.CommandContract.Update(contract);
            SaveChanges();
            return contract;
        }
    }
}