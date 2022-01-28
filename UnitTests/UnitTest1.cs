using System;
using Xunit;
using gamblingSite.Controllers;
using gamblingSite.Services;
using gamblingSite.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void testAddRouletteRecord()
        {
            ICrudPromoCodeRepository pRespository = new UnitTestsPromoCodeRepository();

            PromoCodeModel model = new PromoCodeModel();

            ApiCasinoController controller = new ApiCasinoController(pRepository);

            controller.AddPromoCode(model);

            
            
        }
    }
}
