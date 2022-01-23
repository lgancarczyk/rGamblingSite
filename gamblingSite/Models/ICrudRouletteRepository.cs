using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public interface ICrudRouletteRepository
    {
        RouletteModel Add(RouletteModel rouletteModel);
        RouletteModel Find(int id);
        int FindLastId();
    }

}

