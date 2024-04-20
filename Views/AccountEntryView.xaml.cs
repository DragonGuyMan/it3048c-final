using IT3048C_Final.ViewModels;

namespace IT3048C_Final.Views;

public partial class AccountEntryView : ContentPage
{
	public AccountEntryView(AccountEntryViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}