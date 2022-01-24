using gamblingSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gamblingSite.Controllers
{
    public class CasinoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private ICrudRouletteRepository rRepository;

        public CasinoController(ICrudRouletteRepository rRepository, UserManager<ApplicationUser> userManager)
        {
            this.rRepository = rRepository;
            _userManager = userManager;
        }

        public IActionResult Roulette()
        {
            //decimal balance = rRepository.GetUserBalance(GetUserId());
            //balance.ToString("0,##");
            ViewBag.Balance = rRepository.GetUserBalance(GetUserId()).ToString("0.##");
            
            var rouletteViewModel = GetInfo();
            
            return View(rouletteViewModel);
        }

        [HttpPost]
        public IActionResult Roulette(RouletteViewModel item, string red, string green, string black)
        {
            if (User.Identity.IsAuthenticated)
            {

                string color = null;

                if (!string.IsNullOrEmpty(red))
                {
                    color = "red";
                }
                if (!string.IsNullOrEmpty(green))
                {
                    color = "green";
                }
                if (!string.IsNullOrEmpty(black))
                {
                    color = "black";
                }
                
                var userId = GetUserId();
                var stake = item.applicationUserRouletteModel.Stake;
                if (stake>rRepository.GetUserBalance(userId) || stake<=0)
                {
                    return RedirectToAction("Roulette", "Casino");
                }
                var spinId = rRepository.FindLastRouletteId();


                rRepository.AddUserRoulette(color, userId, stake, spinId);

                System.Diagnostics.Debug.WriteLine(color);
                System.Diagnostics.Debug.WriteLine(stake);

                return RedirectToAction("Roulette", "Casino");
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            
        }
        public RouletteViewModel GetInfo()
        {
            RouletteViewModel rouletteViewModel = new RouletteViewModel();
            int id = rRepository.FindLastRouletteId();
            RouletteModel item = rRepository.FindRoulette(id);
            rouletteViewModel.rouletteModel = item;
            rouletteViewModel.rouletteModels = rRepository.FindLast20Colors();
            rouletteViewModel.applicationUserRouletteModels = rRepository.FindUsersInGame();
            return rouletteViewModel;
        }

        private string GetUserId() 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
        public ActionResult RefreshRouletteCounter()
        {
            int id = rRepository.FindLastRouletteId();
            return PartialView(rRepository.FindRoulette(id)); 
        }

    }
}
