/* using System.Collections.Generic;
using System.Linq;
using Backend_RentHouse_Khalifa_Sami.Model;

namespace Backend_RentHouse_Khalifa_Sami.Data.HistoryData
{
    public class SqlHistoryRepo : IHistoryRepo
    {
        private readonly MyDbContext _context;

        public SqlHistoryRepo(MyDbContext context)
        {
            _context = context;
        }

        public void createHistory(HistoryContract h)
        {
            _context.Add(h);
            _context.SaveChanges();
        }

        public IEnumerable<HistoryContract> getAllHistories()
        {
            return _context.CommandHistory.ToList();
        }

        public HistoryContract getHistoryById(int id)
        {
            return _context.CommandHistory.Find(id);
        }

        

    }
} */