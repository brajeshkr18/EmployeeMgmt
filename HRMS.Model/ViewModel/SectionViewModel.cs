//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS.ViewModel
{
    using System;
    using System.Collections.Generic;
    
    public  class SectionViewModel
    {
        public SectionViewModel()
        {
            this.Employees = new HashSet<EmployeeViewModel>();
        }
    
        public int SecID { get; set; }
        public string Section_Name { get; set; }
    
        public virtual ICollection<EmployeeViewModel> Employees { get; set; }
    }
}