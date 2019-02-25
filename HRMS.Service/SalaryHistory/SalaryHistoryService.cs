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

namespace HRMS.Service.SalaryHistory
{
    public class SalaryHistoryService : ISalaryHistoryService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public dynamic SalaryHistoryList()
        {
            var salaryhistories = _Context.SalaryHistories.Include(s => s.Employee).Include(s => s.Promotion);
            return salaryhistories.ToList();
        }
        public dynamic SalaryHistory(int? id)
        {
            SalaryHistoryViewModel comp = new SalaryHistoryViewModel();
            HRMS.Core.EntityModel.SalaryHistory EntComp = new HRMS.Core.EntityModel.SalaryHistory();
            try
            {
                if (id != 0 && id != null)
                {
                    EntComp = _Context.SalaryHistories.Find(id);
                    Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveSalaryHistory(SalaryHistoryViewModel dept)
        {
            HRMS.Core.EntityModel.SalaryHistory tblSalaryHistory = new HRMS.Core.EntityModel.SalaryHistory();
            bool result = false;
            try
            {
                if (dept.SalaryHistoryID == 0)
                {
                    Mapper.Map(dept, tblSalaryHistory);
                    _Context.SalaryHistories.Add(tblSalaryHistory);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(dept, tblSalaryHistory);
                    _Context.Entry(tblSalaryHistory).State = EntityState.Modified;
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
        public bool DeleteSalaryHistory(int id)
        {
            try
            {

                HRMS.Core.EntityModel.SalaryHistory comp = _Context.SalaryHistories.Find(id);
                _Context.SalaryHistories.Remove(comp); ;
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
