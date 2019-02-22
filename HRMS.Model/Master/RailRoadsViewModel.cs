using System;
using System.Collections.Generic;

namespace HRMS.Model.Master
{
    public class RailRoadsViewModel
    {
        public RailRoadsViewModel()
        {
            CreatedOn = DateTime.Now;
            IsDeleted = false;
            IsActive = true;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public long Createdby { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public Nullable<long> CompanyId { get; set; }
    }
}
