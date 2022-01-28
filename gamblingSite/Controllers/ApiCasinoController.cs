using gamblingSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace gamblingSite.Controllers
{
    [ApiController]
    [Authorize]
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

        

        [Route("GetLastRouletteSpins/{number}")]
        [HttpGet]
        [Authorize]
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
                if (pRepository.isCodeInDatabase(_model.PromoCode))
                {
                    return BadRequest("Code Already Exists");
                }
                else
                {
                    PromoCodeModel model = pRepository.AddPromoCode(_model);
                    return new CreatedResult($"/api/{model.PromoCodeId}", model);
                }
                
            }
            else
            {
                return BadRequest();
            }

        }

        
        [Route("UsePromoCode")]
        [HttpPost]
        [Authorize]
        public ActionResult UsePromoCode([FromBody] PromoCodeModel _model) 
        {
            if (ModelState.IsValid)
            {
                int codeId = pRepository.FindPromoCodeId(_model.PromoCode);
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (pRepository.isCodeValid(_model.PromoCode))
                {
                    if (pRepository.isCodeUsed(userId, codeId))
                    {
                        return BadRequest("Invalid or used code");
                    }
                    else
                    {
                        pRepository.UsePromoCode(userId, codeId);
                        return new CreatedResult($"/api", $"{_model.PromoCode} just has been used");
                    }
                }
                else
                {
                    return BadRequest("Invalid or used code");
                }




            }
            return BadRequest();
        }

        [Route("GetMyBalance")]
        [HttpGet]
        [Authorize]
        public ActionResult GetMyBalance() 
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return new CreatedResult("/api",$"Your balance: {rRepository.GetUserBalance(userId)}");
        }


        [Route("EnterRouletteGame")]
        [HttpPost]
        [Authorize]
        public ActionResult EnterRouletteGame( ApplicationUserRouletteModel _model) 
        {
            if (ModelState.IsValid) 
            {
                ApplicationUserRouletteModel model = new ApplicationUserRouletteModel();

                model.Colour = _model.Colour;
                model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                model.Stake = _model.Stake;
                if (model.Stake > rRepository.GetUserBalance(model.UserId) || model.Stake <= 0)
                {
                    return BadRequest("Invalid Stake");
                }
                model.SpinId = rRepository.FindLastRouletteId();
                rRepository.AddUserRoulette(model);
                return new CreatedResult("/api", $"{model.Colour}: {model.Stake}");
            }
            else
            {
                return BadRequest();
            }
        }


        [Route("Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email

                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return new CreatedResult($"/api/{user.Email}", $"{user.Email} Registered and Logged In");
                }

            }
            return BadRequest();
        }


        [Route("Login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return new CreatedResult($"/api/{user.Email}",  $"{user.Email} logged In");
                }

            }
            return BadRequest();
        }


        [Route("LogOut")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            
            await _signInManager.SignOutAsync();

            return new CreatedResult($"/api/logged_out","Logged Out");
        }



    }
}
