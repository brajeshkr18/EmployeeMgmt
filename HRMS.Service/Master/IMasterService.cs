using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Master
{
    public interface IMasterService
    {
        dynamic Benefits(int? id);
        dynamic Departments(int? id);
        dynamic Designations(int? id);
        dynamic Divisions(int? id);
        dynamic Employee_Type(int? id);
        dynamic Grades(int? id);
        dynamic Sections(int? id);



    }
}
