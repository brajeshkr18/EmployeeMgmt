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
using HRMS.Service.Division;

namespace HRMS.Service.Division
{
    public class DivisionService : IDivisionService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public dynamic DivisionList()
        {
            //List<DivisionViewModel> desList = new List<DivisionViewModel>();
            var Divisions = _Context.Divisions.Include(d => d.Company).ToList();
           // Mapper.Map(Divisions, desList);
            return Divisions;
        }
        public DivisionViewModel Division(int? id)
        {
            DivisionViewModel avm = new DivisionViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Division Division = _Context.Divisions.Find(id);
                    Mapper.Map(Division, avm);
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
        public bool SaveDivision(HRMS.ViewModel.DivisionViewModel atten)
        {
            HRMS.Core.EntityModel.Division tblattend = new HRMS.Core.EntityModel.Division();
            bool result = false;
            try
            {
                if (atten.DivID == 0)
                {
                    Mapper.Map(atten, tblattend);
                    _Context.Divisions.Add(tblattend);
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
        public bool DeleteDivision(int id)
        {
            try
            {
                HRMS.Core.EntityModel.Division Division = _Context.Divisions.Find(id);
                _Context.Divisions.Remove(Division); ;
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
