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
        public bool isCodeInDatabase(string code);
        //public bool isCodeActive(string code);
        //public void ChangeCodeStatus(string code);
        //public PromoCodeModel GetPromoCodeModel(string promoCode);
        public void UsePromoCode(string userId, int codeId);
        public int FindPromoCodeId(string code);
        public decimal FindPromoCodeValue(int codeId);
        IList<PromoCodeModel> FindAllPromoCodes();

    }
}
