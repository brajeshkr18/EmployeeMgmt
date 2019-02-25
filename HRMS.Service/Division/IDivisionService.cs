using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Division
{
    public interface IDivisionService
    {

        dynamic DivisionList();
        dynamic Division(int? id);
        dynamic EmployeeList();
        bool SaveDivision(HRMS.ViewModel.DivisionViewModel atten);
        bool DeleteDivision(int id);
    }
}
