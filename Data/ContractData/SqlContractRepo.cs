using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Data.ContractData
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
            if(GetContractById(id) != null){
               _context.CommandContract.Remove(GetContractById(id));
                SaveChanges();
            }
            
            return GetAllContracts(); 
            
        }

        public IEnumerable<Contract> GetAllContracts()
        {
            return _context.CommandContract.ToList();
        }

        public Contract GetContractById(int id)
        {
            return _context.CommandContract.FirstOrDefault(c => c.idContract == id);
        }
        public Contract GetClientContractById(int id)
        {
            return _context.CommandContract.FirstOrDefault(c => c.clientId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Contract UpdateContract(Contract contract)
        {
            _context.CommandContract.Update(contract);
            SaveChanges();
            return contract;
        }
    }
}