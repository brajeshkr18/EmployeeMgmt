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

namespace HRMS.Service.Master
{
    public class MasterService : IMasterService
    {

        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        public dynamic Benefits(int? id)
        {
            if (id == 0 || id==null)
            {
                return _Context.Benefits;
            }
            return _Context.Benefits.Find(id);
        }
        public dynamic Departments(int? id)
        {
            if (id == 0 || id == null)
            {
                return _Context.Departments;
            }
            return _Context.Departments.Find(id);
        }
        public dynamic Designations(int? id)
        {
            if (id == 0 || id == null)
            {
                return _Context.Designations;
            }
            return _Context.Designations.Find(id);
        }
        public dynamic Divisions(int? id)
        {
            if (id == 0 || id == null)
            {
                return _Context.Divisions;
            }
            return _Context.Divisions.Find(id);
        }
        public dynamic Employee_Type(int? id)
        {
            if (id == 0 || id == null)
            {
                return _Context.Employee_Type;
            }
            return _Context.Employee_Type.Find(id);
        }
        public dynamic Grades(int? id)
        {
            if (id == 0 || id == null)
            {
                return _Context.Grades;
            }
            return _Context.Grades.Find(id);
        }
        public dynamic Sections(int? id)
        {
            if (id == 0 || id == null)
            {
                return _Context.Sections;
            }
            return _Context.Sections.Find(id);
        }


        #endregion
    }
}
