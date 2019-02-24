
using System;
using System.ComponentModel.DataAnnotations;

namespace HRMS.ViewModel
{
  
    
    public  class AttendenceViewModel
    {
        public int ID { get; set; }
        [Required]
        public string InTime { get; set; }
        [Required]
        public string OutTime { get; set; }
        [Display(Name = "InTime Lanch")]
        public string InTime_Lanch { get; set; }
        [Display(Name = "OutTime Lanch")]
        public string OutTime_Lanch { get; set; }
        [Required]
        [Display(Name = "Attend Date")]
        public Nullable<System.DateTime> Attend_Date { get; set; }
        public string Statuss { get; set; }
        [Required]
        public Nullable<int> EmpID { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}
