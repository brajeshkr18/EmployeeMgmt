using System;
namespace HRMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public  class Transfer_InfoViewModel
    {
        public int TransferID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public string OldDepartment { get; set; }
        public string NewDepartment { get; set; }
        public string OldDivision { get; set; }
        public string NewDivision { get; set; }
        public string OldSection { get; set; }
        public string NewSection { get; set; }
        public Nullable<System.DateTime> TransferActiveDate { get; set; }
        public Nullable<System.DateTime> TransferDate { get; set; }
        public string Remark { get; set; }
        public string StatusState { get; set; }
    
        public virtual EmployeeViewModel Employee { get; set; }
    }
}
