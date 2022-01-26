using gamblingSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("Api")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ApiCasinoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ICrudRouletteRepository rRepository;
        private ICrudPromoCodeRepository pRepository;

        public ApiCasinoController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    ICrudRouletteRepository rRepository,
                                    ICrudPromoCodeRepository pRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.rRepository = rRepository;
            this.pRepository = pRepository;
        }




        [Authorize]
        [Route("GetLastRouletteSpins")]
        [HttpGet]
        public IList<RouletteModel> GetLastRouletteSpins(int number)
        {
            return rRepository.FindLastSpins(number);
        }


        [Route("GetAppPromoCodes")]
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IList<PromoCodeModel> GetAppPromoCodes() 
        {
            return pRepository.FindAllPromoCodes();
        }

        [Route("AddPromoCode")]
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddPromoCode([FromBody] PromoCodeModel _model)
        {
            if (ModelState.IsValid)
            {
                PromoCodeModel model = pRepository.AddPromoCode(_model);
                return new CreatedResult($"/api/{model.PromoCodeId}", model);
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
