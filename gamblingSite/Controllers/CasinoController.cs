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

        //private ICrudRouletteRepository repository;

        //public CasinoController(ICrudRouletteRepository repository)
        //{
        //    this.repository = repository;
        //}

        //do tąd dodane chwilowo
        public IActionResult Roulette()
        {
            return View();
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

        public IActionResult AddRouletteInDatabase()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult AddRoulette(RouletteModel item)
        //{
        //    item.SpinDate = DateTime.Now;
        //    repository.Add(item);
        //    return View("Roulette");
        //}
    }
}
