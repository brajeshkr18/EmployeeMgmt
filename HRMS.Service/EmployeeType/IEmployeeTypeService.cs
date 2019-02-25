using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.EmployeeType
{
    public interface IEmployeeTypeService
    {

        List<Employee_TypeViewModel> EmployeeTypeList();
        Employee_TypeViewModel EmployeeType(int? id);
        bool SaveEmployeeType(Employee_TypeViewModel empType);
        bool DeleteEmployeeType(int id);
    }
}
