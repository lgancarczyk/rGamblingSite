using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class ApplicationUserRouletteModelRepository : IApplicationUserRouletteModelRepository
    {
        private AppDBContext _context;
        public ApplicationUserRouletteModelRepository(AppDBContext context)
        {
            _context = context;
        }
                
        public ApplicationUserRouletteModel Add(ApplicationUserRouletteModel applicationUserRouletteModel)
        {
            throw new NotImplementedException();
        }

        public ApplicationUserRouletteModel Find(string userId, int spinId)
        {
            throw new NotImplementedException();
        }
    }
}
