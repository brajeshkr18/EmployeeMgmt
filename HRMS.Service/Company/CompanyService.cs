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

namespace HRMS.Service.Company
{
    public class CompanyService : ICompanyService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public dynamic AttendenceList()
        {
            var attendences = _Context.Attendences.Include(a => a.Employee);
            return attendences.ToList();
        }
        public AttendenceViewModel Attendence(int? id)
        {
            AttendenceViewModel avm = new AttendenceViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    Attendence attendence = _Context.Attendences.Find(id);
                    Mapper.Map(attendence, avm);
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
        public bool SaveAttendence(HRMS.ViewModel.AttendenceViewModel atten)
        {
            HRMS.Core.EntityModel.Attendence tblattend = new HRMS.Core.EntityModel.Attendence();
            bool result = false;
            try
            {
                if (atten.ID == 0)
                {
                    Mapper.Map(atten, tblattend);
                    _Context.Attendences.Add(tblattend);
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
        public bool DeleteAttendence(int id)
        {
            try
            {
                HRMS.Core.EntityModel.Attendence attendence = _Context.Attendences.Find(id);
                _Context.Attendences.Remove(attendence); ;
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
