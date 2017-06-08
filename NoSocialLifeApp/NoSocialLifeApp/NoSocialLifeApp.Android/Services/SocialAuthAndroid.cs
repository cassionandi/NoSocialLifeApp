using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using NoSocialLifeApp.Droid.Services;
using NoSocialLifeApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthAndroid))]
namespace NoSocialLifeApp.Droid.Services
{
    public class SocialAuthAndroid : ISocialAuth
    {

        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}