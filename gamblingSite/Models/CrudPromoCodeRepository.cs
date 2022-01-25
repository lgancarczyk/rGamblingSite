using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamblingSite.Models;

namespace gamblingSite.Models
{
    public class CrudPromoCodeRepository : ICrudPromoCodeRepository
    {
        private AppDBContext _context;
        public CrudPromoCodeRepository(AppDBContext context)
        {
            _context = context;
        }

        public void AddPromoCode(PromoCodeModel promoCodeModel)
        {
            _context.PromoCodeModels.Add(promoCodeModel);
            _context.SaveChanges();
        }

        public RouletteModel AddRoulette(RouletteModel rouletteModel)
        {
            throw new NotImplementedException();
        }

        public IList<PromoCodeModel> FindAllPromoCodes()
        {
            return _context.PromoCodeModels.ToList();
        }

        public int FindPromoCodeId(string code)
        {
            return _context.PromoCodeModels.Where(x => x.PromoCode == code)
                .Select(x => x.PromoCodeId).FirstOrDefault();
        }

        public decimal FindPromoCodeValue(int codeId)
        {
            return _context.PromoCodeModels.Where(x => x.PromoCodeId == codeId)
                .Select(x => x.CodeValue).FirstOrDefault();
        }

        public bool isCodeInDatabase(string code)
        {
            var cc = _context.PromoCodeModels.Where(x => x.PromoCode == code).FirstOrDefault();
            if (cc is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isCodeUsed(string userId, int codeId)
        {
            var cc = _context.ApplicationUserPromoCodeModels.Where(x => x.UserId == userId && x.PromoCodeId == codeId).FirstOrDefault();
            if (cc is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isCodeValid(string code)
        {
            var isValid = _context.PromoCodeModels.Where(x => x.PromoCode == code).FirstOrDefault();
            if (isValid is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UsePromoCode(string userId, int codeId)
        {
            decimal value = FindPromoCodeValue(codeId);
            ApplicationUser user = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();
            user.WalletSize = user.WalletSize + value;
            _context.SaveChanges();

            ApplicationUserPromoCodeModel model = new ApplicationUserPromoCodeModel();
            model.UserId = userId;
            model.PromoCodeId = codeId;
            _context.ApplicationUserPromoCodeModels.Add(model);
            _context.SaveChanges();
            
        }
    }
}
