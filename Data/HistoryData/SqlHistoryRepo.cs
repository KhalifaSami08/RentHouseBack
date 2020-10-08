using System.Collections.Generic;
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

        public void createHistory(History h)
        {
            _context.Add(h);
            saveChanges();
        }

        public IEnumerable<History> getAllHistories()
        {
            return _context.CommandHistory.ToList();
        }

        public History getHistoryById(int id)
        {
            return _context.CommandHistory.Find(id);
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}