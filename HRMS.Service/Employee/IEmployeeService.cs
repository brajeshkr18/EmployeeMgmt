using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Employee
{
    public interface IEmployeeService
    {
        /// <summary>
        /// User authentication on login
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        dynamic EmployeeList();
        EmployeeViewModel Employee(int? id);
        bool SaveEmployee(HRMS.ViewModel.EmployeeViewModel emp);
        bool DeleteEmployee(int id);
    }
}
