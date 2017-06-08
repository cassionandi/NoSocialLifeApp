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

        public string UrlFBUserImage
        {
            get
            {
                return $"https://graph.facebook.com/{User?.UserId}/picture?type=large&hc_location=ufi";
            }
        }

        private AppIdentity identity;

        private MobileServiceUser user;

        public MobileServiceUser User
        {
            get { return user; }
            set {
                SetProperty(ref user, value);
                RaisePropertyChanged("IsFacebookButtonVisible");
                RaisePropertyChanged("IsContinuarButtonVisible");
                RaisePropertyChanged("UrlFBUserImage");

            }
        }

        public Command ShowLoginCommand { get; }

        public Command LogoutCommand { get; }

        public Command ShowMainCommand { get; }

        public LoginViewModel()
        {
            ShowLoginCommand = new Command(ExecuteLoginCommand);

            LogoutCommand = new Command(ExecuteLogoutCommand);

            ShowMainCommand = new Command(ExecuteShowMainCommand);
        }

        private async void ExecuteShowMainCommand()
        {
            await PushAsync<MainViewModel>();
        }

        private async void ExecuteLoginCommand()
        {
            
            AzureService azureService = new AzureService();
            User = await azureService.LoginAsync();
            identity = await FacebookClient.GetIdentity(User.MobileServiceAuthenticationToken);

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
