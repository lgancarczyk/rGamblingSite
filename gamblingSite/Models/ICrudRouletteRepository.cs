using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public interface ICrudRouletteRepository
    {
        RouletteModel AddRoulette(RouletteModel rouletteModel);
        RouletteModel FindRoulette(int id);
        public void AddUserRoulette(string color, string userId, decimal stake, int spinId);
        int FindLastRouletteId();
    }

}

