using SQLite;

namespace IT3048C_Final.Models
{
    public class AccountEntry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
