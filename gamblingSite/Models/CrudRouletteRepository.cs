using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace gamblingSite.Models
{
    public class CrudRouletteRepository : ICrudRouletteRepository
    {
        private AppDBContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public CrudRouletteRepository(AppDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public RouletteModel AddRoulette(RouletteModel rouletteModel)
        {
            var entity = _context.RouletteModels.Add(rouletteModel).Entity;
            _context.SaveChanges();
            return entity;

        }

        public RouletteModel FindRoulette(int id)
        {
            return _context.RouletteModels.Find(id);
        }

        public int FindLastRouletteId()
        {
            int id = _context.RouletteModels.Max(p => p.SpinID);
            return id;
        }

        //ApplicationUserRouletteModel AddUserRoulette(ApplicationUserRouletteModel model)
        //{
            
        //    //item.Colour = color;
        //    //item.UserId = userId;
        //    //item.Stake = stake;
        //    //item.SpinId = spinId;
        //    var entity = _context.ApplicationUserRouletteModels.Add(model).Entity;
        //    _context.SaveChanges();
        //    ReduceUserBalance(model.UserId, model.Stake);
        //    return entity;

        //}

        public decimal GetUserBalance(string id)
        {
            var result = (from p in _context.ApplicationUsers
                          where p.Id == id
                          select p.WalletSize).FirstOrDefault();

            return result;
        }

        public void ReduceUserBalance(string userId, decimal stake)
        {
            var newBalance = GetUserBalance(userId) - stake;
            ApplicationUser user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == userId);
            user.WalletSize = newBalance;
            _context.SaveChanges();
        }

        public IList<RouletteModel> FindLastSpins(int number = 20)
        {
            return _context.RouletteModels.Where(x => x.Colour != null)
                .OrderByDescending(x => x.SpinID)
                .Take(20).ToList();
        }

        public IList<ApplicationUserRouletteModel> FindUsersInGame()
        {
            int gameId = FindLastRouletteId();
            return _context.ApplicationUserRouletteModels.Where(x => x.SpinId == gameId).ToList();
                
        }

        ApplicationUserRouletteModel ICrudRouletteRepository.AddUserRoulette(ApplicationUserRouletteModel model)
        {
            var entity = _context.ApplicationUserRouletteModels.Add(model).Entity;
            _context.SaveChanges();
            ReduceUserBalance(model.UserId, model.Stake);
            return entity;
        }
    }
}
