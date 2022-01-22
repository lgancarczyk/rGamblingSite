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
            //throw new NotImplementedException();
            var entity = _context.RouletteModels.Add(rouletteModel).Entity;
            _context.SaveChanges();
            return entity;

        }

        public RouletteModel Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
