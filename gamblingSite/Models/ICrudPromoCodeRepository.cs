using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public interface ICrudPromoCodeRepository
    {
        RouletteModel AddRoulette(RouletteModel rouletteModel);
        PromoCodeModel AddPromoCode(PromoCodeModel promoCodeModel);
        public bool isCodeUsed(string userId, int codeId);
        public bool isCodeValid(string code);
        public void UsePromoCode(string userId, int codeId);
        public int FindPromoCodeId(string code);
        public decimal FindPromoCodeValue(int codeId);

    }
}
