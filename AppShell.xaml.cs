using IT3048C_Final.Views;

namespace IT3048C_Final
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AccountEntryView), typeof(AccountEntryView));
            Routing.RegisterRoute(nameof(AccountListView), typeof(AccountListView));
            this.GoToAsync("//AccountList");
        }
    }
}
