using IT3048C_Final.Models;
using IT3048C_Final.ViewModels;

namespace IT3048C_Final.Views;

public partial class AccountListView : ContentPage
{
	public AccountListView(AccountEntryViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
    private async void AddAccount(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AccountEntry");
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