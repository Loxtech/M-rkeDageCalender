namespace DataAccessLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime birthday { get; set; }
    }

    public class UserLists
    {
        public List<UserModel> ListofUsers { get; set; }
    }
}
