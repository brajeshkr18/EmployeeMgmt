using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Promotion
{
    public interface IPromotionService
    {

        List<PromotionViewModel> PromotionList();
        PromotionViewModel Promotion(int? id);
        bool SavePromotion(PromotionViewModel atten);
        bool DeletePromotion(int id);
    }
}
