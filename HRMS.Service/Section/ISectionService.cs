using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Master;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Section
{
    public interface ISectionService
    {

        List<SectionViewModel> SectionList();
        SectionViewModel Section(int? id);
        bool SaveSection(SectionViewModel atten);
        bool DeleteSection(int id);
    }
}
