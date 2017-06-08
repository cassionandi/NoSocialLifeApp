using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSocialLifeApp.Models
{

    /*
    public class RootobjectAppIdentity
    {
        public List<AppServiceIdentity> AppIdentity { get; set; }
    }

    public class AppServiceIdentity
    {
        public string access_token { get; set; }
        public DateTime expires_on { get; set; }
        public string provider_name { get; set; }
        public UserClaims[] user_claims { get; set; }
        public string user_id { get; set; }
    }

    public class UserClaims
    {
        public string typ { get; set; }
        public string val { get; set; }
    }
    */
    public class UserClaim
    {

        [JsonProperty("typ")]
        public string typ { get; set; }

        [JsonProperty("val")]
        public string val { get; set; }
    }

    public class AppIdentity
    {

        [JsonProperty("access_token")]
        public string access_token { get; set; }

        [JsonProperty("expires_on")]
        public DateTime expires_on { get; set; }

        [JsonProperty("provider_name")]
        public string provider_name { get; set; }

        [JsonProperty("user_claims")]
        public IList<UserClaim> user_claims { get; set; }

        [JsonProperty("user_id")]
        public string user_id { get; set; }
    }

    public class RootObject
    {
        public AppIdentity identity;
    }

}
