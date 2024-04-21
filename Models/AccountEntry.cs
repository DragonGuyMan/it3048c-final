//using SQLite;

//namespace IT3048C_Final.Models
//{
//    public class AccountEntry
//    {
//        [PrimaryKey, AutoIncrement]
//        public int ID { get; set; }
//        [Unique]
//        public string Name { get; set; }

//        public string Username { get; set; }

//        public string Password { get; set; }
//    }
//}

using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace IT3048C_Final.Models
{
    public class AccountEntry : ObservableObject
    {
        private int id; // Non-nullable
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private string name = ""; // Initialize with an empty string
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string username = ""; // Initialize with an empty string
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        private string password = ""; // Initialize with an empty string
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
    }
}
