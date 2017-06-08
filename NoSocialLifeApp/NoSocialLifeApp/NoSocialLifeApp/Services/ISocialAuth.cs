using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace NoSocialLifeApp.Services
{
    public interface ISocialAuth
    {
    
      Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider);

    }
}