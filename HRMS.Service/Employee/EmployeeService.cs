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

namespace HRMS.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public dynamic EmployeeList()
        {
            List<HRMS.ViewModel.EmployeeViewModel> EmpList = new List<HRMS.ViewModel.EmployeeViewModel>();

            var emp = _Context.Employees.Include(e => e.Benefit).Include(e => e.Department).
               Include(e => e.Designation).Include(e => e.Division).Include(e => e.Employee_Type).Include(e => e.Grade).Include(e => e.Section);
             return emp.ToList();
        }
        public EmployeeViewModel Employee(int? id)
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                     var employee = _Context.Employees.Find(id);
                    Mapper.Map(employee, emp);
                }
            }
            catch (Exception EX)
            {

            }
            return emp;
        }
        public bool SaveEmployee(HRMS.ViewModel.EmployeeViewModel emp)
        {
            HRMS.Core.EntityModel.Employee tblemp = new HRMS.Core.EntityModel.Employee();
            bool result = false;
            try
            {
                if (emp.EmpID == 0)
                {
                    Mapper.Map(emp, tblemp);
                    _Context.Employees.Add(tblemp);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(emp, tblemp);
                    _Context.Entry(tblemp).State = EntityState.Modified;
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
        public bool DeleteEmployee(int id)
        {
            try
            {
                HRMS.Core.EntityModel.Employee employee = _Context.Employees.Find(id);
                _Context.Employees.Remove(employee);
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
