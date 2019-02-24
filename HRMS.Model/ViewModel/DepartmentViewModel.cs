

using System.Collections.Generic;

namespace HRMS.ViewModel
{
   
    public  class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            this.Employees = new List<EmployeeViewModel>();
        }
    
        public int DID { get; set; }
        public string DName { get; set; }
    
        public  List<EmployeeViewModel> Employees { get; set; }
    }
}
