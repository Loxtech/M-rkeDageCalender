namespace DataAccessLibrary.Models
{
    public class PublicHolidayModel
    {
        public DateTime date { get; set; }
        public string name { get; set; }
        public string nationalHoliday { get; set; }
    }

    public class PublicHolidayLists
    {
        public List<PublicHolidayModel> ListofHolidays { get; set; }
    }
}
