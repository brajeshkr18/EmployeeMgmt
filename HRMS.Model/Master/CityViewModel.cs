namespace HRMS.Model.Master
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State_Id { get; set; }

        public virtual StateViewModel State { get; set; }
    }
}
