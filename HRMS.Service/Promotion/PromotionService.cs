using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using HRMS.Core.EntityModel;
using HRMS.ViewModel.Model.Users;
using HRMS.ViewModel;
using HRMS.Model.Users;
using HRMS.Model.Master;
using HRMSModel.ViewModel;
using System.Data.Entity;

namespace HRMS.Service.Promotion
{
    public class PromotionService : IPromotionService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<PromotionViewModel> PromotionList()
        {
            List<PromotionViewModel> pro = new List<PromotionViewModel>();
            var promotions = _Context.Promotions.Include(p => p.Employee).ToList();
            Mapper.Map(promotions, pro);
            return pro;
        }
        public PromotionViewModel Promotion(int? id)
        {
            PromotionViewModel comp = new PromotionViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Promotion EntComp = _Context.Promotions.Find(id);
                    Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SavePromotion(PromotionViewModel dept)
        {
            HRMS.Core.EntityModel.Promotion tblPromotion = new HRMS.Core.EntityModel.Promotion();
            bool result = false;
            try
            {
                if (dept.PromotionID == 0)
                {
                    Mapper.Map(dept, tblPromotion);
                    _Context.Promotions.Add(tblPromotion);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(dept, tblPromotion);
                    _Context.Entry(tblPromotion).State = EntityState.Modified;
                    _Context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception EX)
            {
                result = false;
            }
            return result;
        }
        public bool DeletePromotion(int id)
        {
            try
            {

                HRMS.Core.EntityModel.Promotion pro = _Context.Promotions.Find(id);
                _Context.Promotions.Remove(pro); ;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}
