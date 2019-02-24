
using System.Collections.Generic;

namespace HRMS.ViewModel
{
  
    
    public  class BenefitViewModel
    {
        public BenefitViewModel()
        {
            this.Employees = new List<EmployeeViewModel>();
        }
    
        public int Benefit_ID { get; set; }
        public string Benefit_Type { get; set; }
    
        public virtual List<EmployeeViewModel> Employees { get; set; }
    }
}
