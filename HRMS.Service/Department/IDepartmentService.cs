using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Department
{
    public interface IDepartmentService
    {

        List<DepartmentViewModel> DepartmentList();
        DepartmentViewModel Department(int? id);
        bool SaveDepartment(DepartmentViewModel atten);
        bool DeleteDepartment(int id);
    }
}
