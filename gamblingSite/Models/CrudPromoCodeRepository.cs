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

        public PromoCodeModel AddPromoCode(PromoCodeModel promoCodeModel)
        {
            //promoCodeModel.IsCodeActive = true;
            var entity = _context.PromoCodeModels.Add(promoCodeModel).Entity;
            _context.SaveChanges();
            return entity;
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


        
        //public bool isCodeActive(string code)
        //{
        //    var item = _context.PromoCodeModels.Where(x => x.PromoCodeId == FindPromoCodeId(code)).FirstOrDefault();
        //    if (item.IsCodeActive == true )
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
            
        //}
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

        //public void ChangeCodeStatus(string code)
        //{
        //    PromoCodeModel model = GetPromoCodeModel(code);
        //    //System.Diagnostics.Debug.WriteLine(model.IsCodeActive);
        //    if (model.IsCodeActive == true)
        //    {
        //        model.IsCodeActive = false;
        //    }
        //    else
        //    {
        //        model.IsCodeActive = true;
        //    }
        //    _context.SaveChanges();
        //}
        

        //public PromoCodeModel GetPromoCodeModel(string promoCode)
        //{
        //    var entity = _context.PromoCodeModels.Where(x => x.PromoCode == promoCode).FirstOrDefault();
        //    return entity;
        //}
    }
}
