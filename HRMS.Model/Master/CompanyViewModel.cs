using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Model.Master
{
    public class CompanyViewModel
    {
       public CompanyViewModel()
        {
            CreatedOn = DateTime.Now;
            IsDeleted = false;
            IsActive = true;
            this.CompanyHistoryList = new List<CompanyViewModel>();
        }
        public long Id { get; set; }
        [Display(Name = "Company Name*")]
        public string Name { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Cost Per Minute *")]
        public Nullable<float> PerMinRate { get; set; }
        [Display(Name = "Load Mile Rate *")]
        public Nullable<float> LoadMileRate { get; set; }
        [Display(Name = "Empty Mile Rate*")]
        public Nullable<float> EmptyMileRate { get; set; }
        public long ModifiedBy { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> RailRoadId { get; set; }
        public List<CompanyViewModel> CompanyHistoryList { get; set; }
        public string StateName { get; set; }
        public string RailRoadName { get; set; }
    }
}
