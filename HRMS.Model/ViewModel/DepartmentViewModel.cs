

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRMS.ViewModel
{
   
    public  class DepartmentViewModel
    {
        public DepartmentViewModel()
        {
            this.Employees = new List<EmployeeViewModel>();
        }
    
        public int DID { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string DName { get; set; }
    
        public  List<EmployeeViewModel> Employees { get; set; }
    }
}
