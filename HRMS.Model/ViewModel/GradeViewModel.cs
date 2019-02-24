
//------------------------------------------------------------------------------

namespace HRMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public  class GradeViewModel
    {
        public GradeViewModel()
        {
            this.Employees = new HashSet<EmployeeViewModel>();
        }
    
        public int GID { get; set; }
        public string Grade_Name { get; set; }
        public Nullable<int> Grade_Salary { get; set; }
    
        public virtual ICollection<EmployeeViewModel> Employees { get; set; }
    }
}
