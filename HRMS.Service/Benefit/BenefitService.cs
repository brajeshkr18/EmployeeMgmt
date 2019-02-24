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

namespace HRMS.Service.Benefit
{
    public class BenefitService : IBenefitService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods


        public List<BenefitViewModel> BenefitList()
        {
            List<BenefitViewModel> bvm = new List<BenefitViewModel>();
            var benifit = _Context.Benefits;
            Mapper.Map(benifit.ToList(), bvm);
            return bvm;
        }
        public BenefitViewModel Benefit(int? id)
        {
            BenefitViewModel bvm = new BenefitViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Benefit benifit = _Context.Benefits.Find(id);
                    Mapper.Map(benifit, bvm);
                }
            }
            catch (Exception EX)
            {

            }
            return bvm;
        }
    
        public bool SaveBenifit(BenefitViewModel benifit)
        {
            HRMS.Core.EntityModel.Benefit tblbenifit = new HRMS.Core.EntityModel.Benefit();
            bool result = false;
            try
            {
                if (benifit.Benefit_ID == 0)
                {
                    Mapper.Map(benifit, tblbenifit);
                    _Context.Benefits.Add(tblbenifit);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(benifit, tblbenifit);
                    _Context.Entry(tblbenifit).State = EntityState.Modified;
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
        public bool DeleteBenifit(int id)
        {
            try
            {
                HRMS.Core.EntityModel.Benefit benifit = _Context.Benefits.Find(id);
                _Context.Benefits.Remove(benifit); ;
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
