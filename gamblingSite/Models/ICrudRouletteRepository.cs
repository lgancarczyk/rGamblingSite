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
        ApplicationUserRouletteModel AddUserRoulette(ApplicationUserRouletteModel applicationUserRouletteModel);
        int FindLastRouletteId();
        IList<RouletteModel> FindLastSpins(int number);
        IList<ApplicationUserRouletteModel> FindUsersInGame();

    }

}

