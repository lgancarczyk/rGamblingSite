using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class CrudRouletteRepository : ICrudRouletteRepository
    {
        private AppDBContext _context;

        public CrudRouletteRepository(AppDBContext context)
        {
            _context = context;
        }

        public RouletteModel Add(RouletteModel rouletteModel)
        {
            var entity = _context.RouletteModels.Add(rouletteModel).Entity;
            _context.SaveChanges();
            return entity;

        }

        public RouletteModel Find(int id)
        {
            return _context.RouletteModels.Find(id);
        }

        public int FindLastId()
        {
            int id = _context.RouletteModels.Max(p => p.SpinID);
            return id;
        }
    }
}
