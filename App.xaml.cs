using IT3048C_Final.Data;

namespace IT3048C_Final
{
    public partial class App : Application
    {

        public static AccountDB Database { get; private set; }

        public App()
        {
            InitializeComponent();
            Database = new AccountDB();
            MainPage = new AppShell();
        }
    }
}
