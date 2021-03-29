namespace Elcom.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Position { get; set; }

        public User(string id, string role)
        {
            Id = id;
            Position = role;
        }
    }
}