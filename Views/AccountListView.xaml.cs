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
    private async void AddAccount(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AccountEntry");
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        AccountList.ItemsSource = await database.GetAccountEntriesAsync();
    }

    private async void CopyPassword(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is AccountEntry account)
        {
            if (!string.IsNullOrEmpty(account.Password))
            {
                await Clipboard.Default.SetTextAsync(account.Password);
                await Shell.Current.DisplayAlert("Success", "Password copied to clipboard.", "OK");
            }
        }
    }
    private async void EditAccount(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is AccountEntry account)
        {
            var navigationParameter = $"?Id={account.ID}&Name={account.Name}&Username={account.Username}&Password={account.Password}";
            await Shell.Current.GoToAsync($"//AccountEntry{navigationParameter}");
        }
    }
}