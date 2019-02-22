using System.Collections.Generic;

namespace HRMS.Model.Master
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
            this.States = new HashSet<StateViewModel>();
        }

        public int Id { get; set; }
        public string Shortname { get; set; }
        public string Name { get; set; }
        public int Phonecode { get; set; }
        
        public virtual ICollection<StateViewModel> States { get; set; }
    }
}
