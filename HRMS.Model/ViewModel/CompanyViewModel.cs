
namespace HRMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public  class CompanyViewModel
    {
        public CompanyViewModel()
        {
            this.Divisions = new List<DivisionViewModel>();
        }
    
        public int CID { get; set; }
        public string CName { get; set; }
        public string Location { get; set; }
    
        public virtual List<DivisionViewModel> Divisions { get; set; }
    }
}
