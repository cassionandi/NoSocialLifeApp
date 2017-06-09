using Microsoft.WindowsAzure.MobileServices;
using NoSocialLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoSocialLifeApp.Services
{
    public class AzureService
    {

        static readonly string AppUrl = "https://nosociallifeapp.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;

        List<AppServiceIdentity> identities = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<ISocialAuth>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente!", "OK");
                });
                return null;
            }

            return user;
        }

        public async Task<AppServiceIdentity> GetIdentityAsync()
        {
            if (Client.CurrentUser == null || Client.CurrentUser?.MobileServiceAuthenticationToken == null)
            {
                throw new InvalidOperationException("Not Authenticated");
            }

            if (identities == null)
            {
                identities = await Client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
            }

            if (identities.Count > 0)
                return identities[0];
            return null;
        }


    }
}
