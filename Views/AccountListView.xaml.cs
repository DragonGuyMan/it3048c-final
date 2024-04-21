using IT3048C_Final.Models;

namespace IT3048C_Final.Views;

public partial class AccountListView : ContentPage
{
	public AccountListView()
	{
		InitializeComponent();
        BindingContext = this;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		AccountsListView.ItemsSource = await App.Database.GetAccountEntriesAsync();
	}

    private async void AddAccount(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AccountEntry");
    }

}