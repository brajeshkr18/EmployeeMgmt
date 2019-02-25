using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.SalaryHistory
{
    public interface ISalaryHistoryService
    {

        dynamic SalaryHistoryList();
        dynamic SalaryHistory(int? id);
        bool SaveSalaryHistory(SalaryHistoryViewModel atten);
        bool DeleteSalaryHistory(int id);
    }
}
