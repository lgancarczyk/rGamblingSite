using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public interface IApplicationUserRouletteModelRepository
    {
        ApplicationUserRouletteModel Add(ApplicationUserRouletteModel applicationUserRouletteModel);
        ApplicationUserRouletteModel Find(string userId, int spinId);
    }
}
