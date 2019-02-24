using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Company
{
    public interface ICompanyService
    {
        
        dynamic AttendenceList();
        AttendenceViewModel Attendence(int? id);
        dynamic EmployeeList();
        bool SaveAttendence(HRMS.ViewModel.AttendenceViewModel atten);
        bool DeleteAttendence(int id);
    }
}
