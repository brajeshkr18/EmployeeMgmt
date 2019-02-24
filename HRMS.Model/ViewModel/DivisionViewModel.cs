
namespace HRMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public  class DivisionViewModel
    {
        public DivisionViewModel()
        {
            this.Employees = new HashSet<EmployeeViewModel>();
        }
    
        public int DivID { get; set; }
        public string Division_Name { get; set; }
        public string Location { get; set; }
        public Nullable<int> CID { get; set; }
    
        public  CompanyViewModel Company { get; set; }
        public  ICollection<EmployeeViewModel> Employees { get; set; }
    }
}
