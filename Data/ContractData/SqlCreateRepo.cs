using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model.Property;

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
            _context.CommandContr.Add(contract);
            SaveChanges();
            return contract;
        }

        public IEnumerable<Contract> DeleteContract(int id)
        {
            _context.CommandContr.Remove(GetContractById(id));
            SaveChanges();
            return GetAllContracts();
        }

        public IEnumerable<Contract> GetAllContracts()
        {
            return _context.CommandContr.ToList();
        }

        public Contract GetContractById(int id)
        {
            return _context.CommandContr.FirstOrDefault(c => c.idContract == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Contract UpdateContract(Contract contract)
        {
            _context.CommandContr.Update(contract);
            SaveChanges();
            return contract;
        }
    }
}