using System;
using System.Collections.Generic;

namespace HRMS.Model.Master
{
    public class StateViewModel
    {
        public StateViewModel()
        {
            this.Cities = new HashSet<CityViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Country_Id { get; set; }
        public Nullable<double> LoadMileRate { get; set; }
        public Nullable<double> CostPerMin { get; set; }
        public Nullable<double> EmptyMileRate { get; set; }
        public virtual ICollection<CityViewModel> Cities { get; set; }
        public virtual CountryViewModel Country { get; set; }
    }
}
