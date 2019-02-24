using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Designation
{
    public interface IDesignationService
    {

        List<DesignationViewModel> DesignationList();
        DesignationViewModel Designation(int? id);
        dynamic EmployeeList();
        bool SaveDesignation(HRMS.ViewModel.DesignationViewModel atten);
        bool DeleteDesignation(int id);
    }
}
