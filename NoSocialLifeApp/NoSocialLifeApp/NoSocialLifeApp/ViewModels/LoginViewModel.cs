using Microsoft.WindowsAzure.MobileServices;
using NoSocialLifeApp.Models;
using NoSocialLifeApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoSocialLifeApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private string nomeUsuario;

        public string NomeUsuario
        {
            get { return nomeUsuario; }
            set { SetProperty(ref nomeUsuario, value); }
        }

        private string urlFBUserImage;

        public string UrlFBUserImage
        {
            get
            {
                return urlFBUserImage;
            }
            set
            {
                SetProperty(ref urlFBUserImage, value);
            }
        }



        private MobileServiceUser user;

        public MobileServiceUser User
        {
            get { return user; }
            set {
                SetProperty(ref user, value);
                RaisePropertyChanged("IsFacebookButtonVisible");
                RaisePropertyChanged("IsContinuarButtonVisible");
            }
        }

        public Command ShowLoginCommand { get; }

        public Command LogoutCommand { get; }

        public Command ShowMainCommand { get; }

        public LoginViewModel()
        {

            Title = "Login";

            ShowLoginCommand = new Command(ExecuteLoginCommand);

            LogoutCommand = new Command(ExecuteLogoutCommand);

            ShowMainCommand = new Command(ExecuteShowMainCommand);
        }

        private async void ExecuteShowMainCommand()
        {
            await PushAsync<MainViewModel>();

            App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 2]);

            

        }

        private async void ExecuteLoginCommand()
        {
            
            AzureService azureService = new AzureService();
            User = await azureService.LoginAsync();
            var identity = await azureService.GetIdentityAsync();

            var userId = identity.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")).Value;

            var nome = identity.UserClaims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")).Value;

            UrlFBUserImage = $"https://graph.facebook.com/{userId}/picture?type=large&hc_location=ufi";

            NomeUsuario = nome;

            Debug.WriteLine("#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ " + User.MobileServiceAuthenticationToken);

        }

        private async void ExecuteLogoutCommand()
        {
            await PushAsync<LoginViewModel>();
        }

        public bool IsFacebookButtonVisible
        {
            get
            {
                return User == null ? true : false;
            }
        }

        public bool IsContinuarButtonVisible
        {
            get
            {
                return User == null ? false : true;
            }
        }

    }
}
