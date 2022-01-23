using gamblingSite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Controllers
{
    public class CasinoController : Controller
    {

        private ICrudRouletteRepository rRepository;
        private IApplicationUserRouletteModelRepository arRepository;

        public CasinoController(
            ICrudRouletteRepository rRepository,
            IApplicationUserRouletteModelRepository arRepository)
        {
            this.rRepository = rRepository;
            this.arRepository = arRepository;
        }

        public IActionResult Roulette()
        {
            int id = rRepository.FindLastId();
            RouletteModel item = rRepository.Find(id);
            return View(item);
        }

        public ActionResult RefreshRouletteCounter()
        {
            int id = rRepository.FindLastId();
            return PartialView(rRepository.Find(id)); 
        }

        [HttpPost]
        public IActionResult Roulette(string bet)
        {
            if (bet == "Red")
            {
                return View("Red");
            }
            return View();
        }

    }
}
