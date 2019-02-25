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

namespace HRMS.Service.EmployeeType
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<Employee_TypeViewModel> EmployeeTypeList()
        {
            List<Employee_TypeViewModel> dep = new List<Employee_TypeViewModel>();
            var dept = _Context.Employee_Type.ToList();
            Mapper.Map(dept, dep);
            return dep;
        }
        public Employee_TypeViewModel EmployeeType(int? id)
        {
            Employee_TypeViewModel comp = new Employee_TypeViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Employee_Type EntComp = _Context.Employee_Type.Find(id);
                    Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveEmployeeType(Employee_TypeViewModel empType)
        {
            HRMS.Core.EntityModel.Employee_Type tblEmployeeType = new HRMS.Core.EntityModel.Employee_Type();
            bool result = false;
            try
            {
                if (empType.EmployeeType_ID == 0)
                {
                    Mapper.Map(empType, tblEmployeeType);
                    _Context.Employee_Type.Add(tblEmployeeType);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(empType, tblEmployeeType);
                    _Context.Entry(tblEmployeeType).State = EntityState.Modified;
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
        public bool DeleteEmployeeType(int id)
        {
            try
            {

                HRMS.Core.EntityModel.Employee_Type empType = _Context.Employee_Type.Find(id);
                _Context.Employee_Type.Remove(empType); ;
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
