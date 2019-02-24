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

namespace HRMS.Service.Designation
{
    public class DesignationService : IDesignationService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<DesignationViewModel> DesignationList()
        {
            List<DesignationViewModel> desList = new List<DesignationViewModel>();
            var Designations = _Context.Designations.ToList();
            Mapper.Map(Designations, desList);
            return desList;
        }
        public DesignationViewModel Designation(int? id)
        {
            DesignationViewModel avm = new DesignationViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Designation Designation = _Context.Designations.Find(id);
                    Mapper.Map(Designation, avm);
                }
            }
            catch (Exception EX)
            {

            }
            return avm;
        }
        public dynamic EmployeeList()
        {
            var employees = _Context.Employees;
            return employees;
        }
        public bool SaveDesignation(HRMS.ViewModel.DesignationViewModel atten)
        {
            HRMS.Core.EntityModel.Designation tblattend = new HRMS.Core.EntityModel.Designation();
            bool result = false;
            try
            {
                if (atten.DesId == 0)
                {
                    Mapper.Map(atten, tblattend);
                    _Context.Designations.Add(tblattend);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(atten, tblattend);
                    _Context.Entry(tblattend).State = EntityState.Modified;
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
        public bool DeleteDesignation(int id)
        {
            try
            {
                HRMS.Core.EntityModel.Designation Designation = _Context.Designations.Find(id);
                _Context.Designations.Remove(Designation); ;
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
