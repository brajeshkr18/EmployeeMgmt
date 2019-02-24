using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Benefit
{
    public interface IBenefitService
    {

        List<BenefitViewModel> BenefitList();
        BenefitViewModel Benefit(int? id);
        bool SaveBenifit(BenefitViewModel benifit);
        bool DeleteBenifit(int id);
    }
}
