
namespace HRMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee_TypeViewModel
    {
        public Employee_TypeViewModel()
        {
            this.Employees = new HashSet<EmployeeViewModel>();
        }
    
        public int EmployeeType_ID { get; set; }
        public string Employee_Types { get; set; }
    
        public virtual ICollection<EmployeeViewModel> Employees { get; set; }
    }
}
