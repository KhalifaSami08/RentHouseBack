using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Data.ContractData
{
    public interface IContractRepo
    {
        bool SaveChanges();
        IEnumerable<Contract> GetAllContracts();
        Contract GetContractById(int id);

        /* //Supprimer une propriété supprime aussi ses contrats. NE SERA PAS UTILISER
        Contract GetPropertyContractById(int id);
        */
        //Supprimer un client supprime aussi ses contrats. NE SERA PAS UTILISER
        Contract GetClientContractById(int id); 

        Contract CreateContract(Contract contract);
        Contract UpdateContract(Contract contract);
        IEnumerable<Contract> DeleteContract(int id);
    }
}