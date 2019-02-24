using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.TransferInfo
{
    public interface ITransferInfoService
    {

        List<Transfer_InfoViewModel> TransferInfoList();
        Transfer_InfoViewModel TransferInfo(int? id);
        bool SaveTransferInfo(Transfer_InfoViewModel atten);
        bool DeleteTransferInfo(int id);
    }
}
