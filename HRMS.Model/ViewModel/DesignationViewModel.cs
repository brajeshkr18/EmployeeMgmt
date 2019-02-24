
namespace HRMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DesignationViewModel
    {
        public DesignationViewModel()
        {
            this.Employees = new HashSet<EmployeeViewModel>();
        }
    
        public int DesId { get; set; }
        public string DesName { get; set; }
    
        public virtual ICollection<EmployeeViewModel> Employees { get; set; }
    }
}
