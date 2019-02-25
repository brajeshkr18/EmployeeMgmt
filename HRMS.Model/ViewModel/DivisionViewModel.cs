using System;
using System.Collections.Generic;
namespace HRMS.ViewModel
{
    public  class DivisionViewModel
    {
        public DivisionViewModel()
        {
            this.Employees = new List<EmployeeViewModel>();
        }
    
        public int DivID { get; set; }
        public string Division_Name { get; set; }
        public string Location { get; set; }
        public Nullable<int> CID { get; set; }
    
        public  CompanyViewModel Company { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
