using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.DAL.ContractData
{
    public interface IContractRepo
    {
        IEnumerable<Contract> GetAllContracts();
        Contract GetContractById(int id);
        Contract GetClientContractById(int id);
        Contract CreateContract(Contract contract);
        Contract UpdateContract(Contract contract);
        IEnumerable<Contract> DeleteContract(int id);
    }
}