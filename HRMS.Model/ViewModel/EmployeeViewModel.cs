using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRMS.ViewModel
{
   
    public  class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            //this.Attendences = new List<AttendenceViewModel>();
            //this.Promotions = new List<PromotionViewModel>();
            //this.SalaryHistories = new List<SalaryHistoryViewModel>();
            //this.Transfer_Info = new List<Transfer_InfoViewModel>();
        }
    
        public int EmpID { get; set; }
        [Required]
        public string Name { get; set; }
        //[Required]
        [Display(Name = "Father Name")]
        public string Father_Name { get; set; }
        [Display(Name = "Mother Name")]
        public string Mother_Name { get; set; }
        [Display(Name = "Date Of Birth")]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Display(Name = "Maritual status")]
        public string Maritual_status { get; set; }
        public string Religion { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name = "Home Phone")]
        public string Home_phone { get; set; }
        [Display(Name = "Present Address")]
        public string Present_address { get; set; }
        [Display(Name = "Parmanent Address")]
        public string parmanent_address { get; set; }
        public Nullable<int> DID { get; set; }
        public Nullable<int> DesId { get; set; }
        public Nullable<int> SecID { get; set; }
        public Nullable<int> DivID { get; set; }
        public Nullable<int> Benefit_ID { get; set; }
        public Nullable<int> EmployeeType_ID { get; set; }
        public Nullable<int> GID { get; set; }
        [Display(Name = "Gross Salary")]
        public Nullable<double> Gross_Salary { get; set; }
    
        //public virtual ICollection<AttendenceViewModel> Attendences { get; set; }
        //public virtual BenefitViewModel Benefit { get; set; }
        //public virtual DepartmentViewModel Department { get; set; }
        //public virtual DesignationViewModel Designation { get; set; }
        //public virtual DivisionViewModel Division { get; set; }
        //public virtual Employee_TypeViewModel Employee_Type { get; set; }
        //public virtual GradeViewModel Grade { get; set; }
        //public virtual SectionViewModel Section { get; set; }
        //public virtual ICollection<PromotionViewModel> Promotions { get; set; }
        //public virtual ICollection<SalaryHistoryViewModel> SalaryHistories { get; set; }
        //public virtual ICollection<Transfer_InfoViewModel> Transfer_Info { get; set; }
    }
}
