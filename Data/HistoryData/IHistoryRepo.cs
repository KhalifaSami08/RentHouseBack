using System.Collections.Generic;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Data.HistoryData
{
    public interface IHistoryRepo
    {
        bool saveChanges();
        IEnumerable<History> getAllHistories();
        History getHistoryById(int id);
        void createHistory(History h);
    }
}