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

        private ICrudRouletteRepository repository;

        public CasinoController(ICrudRouletteRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Roulette()
        {
            int id = repository.FindLastId();
            RouletteModel item = repository.Find(id);
            return View(item);
        }

        public ActionResult RefreshRouletteCounter()
        {
            int id = repository.FindLastId();
            return PartialView(repository.Find(id)); 
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
