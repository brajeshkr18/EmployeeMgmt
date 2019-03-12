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

namespace HRMS.Service.Department
{
    public class DepartmentService : IDepartmentService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<DepartmentViewModel> DepartmentList()
        {
            List<DepartmentViewModel> dep = new List<DepartmentViewModel>();
            var dept = _Context.Departments.ToList();
            Mapper.Map(dept, dep);
            return dep;
        }
        public DepartmentViewModel Department(int? id)
        {
            DepartmentViewModel comp = new DepartmentViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Department EntComp = _Context.Departments.Find(id);
                    Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveDepartment(DepartmentViewModel dept)
        {
            HRMS.Core.EntityModel.Department tblDepartment = new HRMS.Core.EntityModel.Department();
            bool result = false;
            try
            {
                if (dept.DID == 0)
                {
                    Mapper.Map(dept, tblDepartment);
                    _Context.Departments.Add(tblDepartment);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(dept, tblDepartment);
                    _Context.Entry(tblDepartment).State = EntityState.Modified;
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
        public bool DeleteDepartment(int id)
        {
            try
            {

                HRMS.Core.EntityModel.Department dep = _Context.Departments.Find(id);
                _Context.Departments.Remove(dep); ;
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
