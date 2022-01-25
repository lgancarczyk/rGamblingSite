﻿using gamblingSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministratorController : Controller
    {
        private ICrudPromoCodeRepository pRepository;
        public AdministratorController(ICrudPromoCodeRepository repository)
        {
            this.pRepository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PromoCodeManager() 
        {
            PromoCodeViewModel model = new PromoCodeViewModel();
            model.PromoCodeModels = pRepository.FindAllPromoCodes();
            

            return View(model);
        }


        public IActionResult AddPromoCode() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddPromoCode(PromoCodeModel model) 
        {
            if (pRepository.isCodeInDatabase(model.PromoCode))
            {
                ViewData["CodeError"] = "Code alredy exists!";
                return View();
            }
            else
            {
                pRepository.AddPromoCode(model);
                return RedirectToAction("PromoCodeManager", "Administrator");
            }
            
        }
    }
}