using System;
using System.Collections.Generic;
namespace HRMS.ViewModel
{
  
    public  class CompanyViewModel
    {
        public CompanyViewModel()
        {
            this.Divisions = new List<DivisionViewModel>();
        }
    
        public int CID { get; set; }
        public string CName { get; set; }
        public string Location { get; set; }
    
        public  List<DivisionViewModel> Divisions { get; set; }
    }
}
