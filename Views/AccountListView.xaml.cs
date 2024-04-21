using IT3048C_Final.Data;
using IT3048C_Final.Models;

namespace IT3048C_Final.Views;

public partial class AccountListView : ContentPage
{
	AccountDB database;

	public AccountListView(AccountDB accountDB)
	{
		InitializeComponent();
        BindingContext = this;
		database = accountDB;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
        AccountList.ItemsSource = await database.GetAccountEntriesAsync();
	}

    private async void AddAccount(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AccountEntry");
    }

}