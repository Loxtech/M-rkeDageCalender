namespace DataAccessLibrary.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? EventName { get; set; }
    }

    public class EventLists
    {
        public List<EventModel> ListofEvents { get; set; }
    }
}
