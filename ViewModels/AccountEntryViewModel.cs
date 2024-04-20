using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IT3048C_Final.Data;
using IT3048C_Final.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IT3048C_Final.ViewModels
{
    [QueryProperty("Id", "Id")]
    [QueryProperty("Name", "Name")]
    [QueryProperty("Username", "Username")]
    [QueryProperty("Password", "Password")]
    public partial class AccountEntryViewModel : ObservableObject
    {
        AccountDB dataAccess;
        public AccountEntryViewModel()
        {
            dataAccess = new AccountDB();

            Task.Run(async () => {
                var items = await dataAccess.GetAccountEntriesAsync();
                if (items.Any())
                {
                    accounts = new ObservableCollection<AccountEntry>(items);
                }
            });
        }

        [ObservableProperty]
        int? id;

        [ObservableProperty]
        string? name;

        [ObservableProperty]
        string? username;

        [ObservableProperty]
        string? password;

        [ObservableProperty]
        ObservableCollection<AccountEntry> accounts;

        [RelayCommand]
        async Task Save()
        {
            //If passwords are enforced
            //Regex isPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Empty Entry", "All entries must be filled", "Close");
                return;
            }


            //if (!isPassword.IsMatch(Password))
            //{
            //    await Shell.Current.DisplayAlert("Invaid Password", "Password must be between 8-15 characters long, contain a combination of uppercase letters, lowercase letters, numbers, and symbols", "Close");
            //    return;
            //}

            if (Id == null)
            {
                var account = new AccountEntry {
                    Name = Name,
                    Username = Username,
                    Password = Password
                };
                accounts.Add(account);
                dataAccess.InsertAccountAsync(account);
            } else
            {
                var account = await dataAccess.GetAccountEntryAsync((int)Id);
                accounts.Remove(account);

                account.Name = Name;
                account.Username = Username;
                account.Password = Password;

                accounts.Add(account);
                dataAccess.UpdateAccountAsync(account);
            }
            

        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync(".."); //Add Password List Page 
        }
    }
}
