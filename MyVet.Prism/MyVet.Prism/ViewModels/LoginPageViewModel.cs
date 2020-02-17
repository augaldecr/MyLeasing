using MyVet.Common.Models;
using MyVet.Common.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyVet.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private string _password;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;

        public LoginPageViewModel(INavigationService navigationService,
            IApiService apiService) 
            : base(navigationService)
        {
            Title = "Login";
            _isEnabled = true;
            _apiService = apiService;
        }

        /*public DelegateCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new DelegateCommand(Login);
                }
                return _loginCommand;
            }
        }*/

        public DelegateCommand LoginCommand => 
            _loginCommand ?? (_loginCommand = new DelegateCommand(Login));

        public string Email { get; set; }
        public string Password { 
            get => _password;
            set => SetProperty(ref _password, value); 
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an Email", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a Password", "Ok");
                return;
            }

            IsRunning = true;
            IsEnabled = false;

            var request = new TokenRequest
            {
                Password = Password,
                Username = Email
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url, "Account", "/CreateToken", request);

            IsRunning = true;
            IsEnabled = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email or password incorrect!", "Ok");
                Password = string.Empty;
                return;
            }
            
            await App.Current.MainPage.DisplayAlert("Ok", "Hell yeah!!!", "Ok");

        }
    }
}
