﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IT3048C_Final.Data;
using IT3048C_Final.Models;
using System.Collections.ObjectModel;

namespace IT3048C_Final.ViewModels
{
    [QueryProperty("Id", "Id")]
    [QueryProperty("Name", "Name")]
    [QueryProperty("Username", "Username")]
    [QueryProperty("Password", "Password")]
    public partial class AccountEntryViewModel : ObservableObject
    {
        readonly AccountDB dataAccess;
        public AccountEntryViewModel(AccountDB accountDB)
        {
            dataAccess = accountDB;

            Task.Run(async () => {
                var items = await dataAccess.GetAccountEntriesAsync();
                if (items.Any())
                {
                    MainThread.BeginInvokeOnMainThread(() => {
                        Accounts = new ObservableCollection<AccountEntry>(items);
                    });
                }
            });
        }

        [ObservableProperty]
        int id;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        ObservableCollection<AccountEntry> accounts = [];

        [RelayCommand]
        async Task Save()
        {
            //If passwords are enforced
            //Regex isPassword = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                // Needs to be current page for alert to appear
                await Shell.Current.CurrentPage.DisplayAlert("Empty Entry", "All entries must be filled", "Close");
                return;
            }


            //if (!isPassword.IsMatch(Password))
            //{
            //    await Shell.Current.DisplayAlert("Invaid Password", "Password must be between 8-15 characters long, contain a combination of uppercase letters, lowercase letters, numbers, and symbols", "Close");
            //    return;
            //}

            // I don't think the Id by itself will ever be null since new AccountEntry items automatically get an Id
            if (Accounts.Where(x => x.ID == Id).FirstOrDefault() == null)
            {
                var account = new AccountEntry {
                    Name = Name,
                    Username = Username,
                    Password = Password
                };
                Accounts.Add(account);
                await dataAccess.InsertAccountAsync(account);
            } else
            {
                var account = await dataAccess.GetAccountEntryAsync(Id);

                account.Name = Name;
                account.Username = Username;
                account.Password = Password;

                Accounts.Add(account);
                await dataAccess.UpdateAccountAsync(account);
            }

            await Shell.Current.GoToAsync("//AccountList");
        }

        [RelayCommand]
        async Task Cancel()
        {
            await Shell.Current.GoToAsync("//AccountList");
        }
    }
}
