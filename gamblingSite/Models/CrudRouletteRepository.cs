﻿using Microsoft.AspNetCore.Identity;
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

        public void AddUserRoulette(string color, string userId, decimal stake, int spinId)
        {
            ApplicationUserRouletteModel item = new ApplicationUserRouletteModel();
            item.Colour = color;
            item.UserId = userId;
            item.Stake = stake;
            item.SpinId = spinId;
            _context.ApplicationUserRouletteModels.Add(item);
            _context.SaveChanges();
            ReduceUserBalance(userId, stake);

        }

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
    }
}
