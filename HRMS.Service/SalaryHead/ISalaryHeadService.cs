using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.SalaryHead
{
    public interface ISalaryHeadService
    {

        List<SalaryHeadViewModel> SalaryHeadList();
        SalaryHeadViewModel SalaryHead(int? id);
        bool SaveSalaryHead(SalaryHeadViewModel atten);
        bool DeleteSalaryHead(int id);
    }
}
