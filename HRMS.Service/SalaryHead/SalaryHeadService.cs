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

namespace HRMS.Service.SalaryHead
{
    public class SalaryHeadService : ISalaryHeadService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<SalaryHeadViewModel> SalaryHeadList()
        {
            List<SalaryHeadViewModel> pro = new List<SalaryHeadViewModel>();
            var SalaryHeads = _Context.SalaryHeads.ToList();
            Mapper.Map( SalaryHeads, pro);
            return pro;
        }
        public SalaryHeadViewModel SalaryHead(int? id)
        {
            SalaryHeadViewModel comp = new SalaryHeadViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.SalaryHead EntComp = _Context.SalaryHeads.Find(id);
                    Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveSalaryHead(SalaryHeadViewModel dept)
        {
            HRMS.Core.EntityModel.SalaryHead tblSalaryHead = new HRMS.Core.EntityModel.SalaryHead();
            bool result = false;
            try
            {
                if (dept.ID == 0)
                {
                    Mapper.Map(dept, tblSalaryHead);
                    _Context.SalaryHeads.Add(tblSalaryHead);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(dept, tblSalaryHead);
                    _Context.Entry(tblSalaryHead).State = EntityState.Modified;
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
        public bool DeleteSalaryHead(int id)
        {
            try
            {

                HRMS.Core.EntityModel.SalaryHead sal = _Context.SalaryHeads.Find(id);
                _Context.SalaryHeads.Remove(sal); ;
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
