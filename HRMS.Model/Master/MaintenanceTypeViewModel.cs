using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Model.Master
{
   public class MaintenanceTypeViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<long> Createdby { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

      
    }
}
