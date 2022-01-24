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
        public decimal GetUserBalance(string id);
        public void ReduceUserBalance(string userId, decimal stake);
        public void AddUserRoulette(string color, string userId, decimal stake, int spinId);
        int FindLastRouletteId();
    }

}

