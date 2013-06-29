using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace ButtonManagerAPISample
{
    public static class Configuration
    {
        //Creates a configuration map containing signature credentials and other required configuration parameters
        public static Dictionary<string, string> GetSignatureConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();

            //Endpoints are varied depending on whether sandbox OR live is chosen for mode
            configMap.Add("mode", "sandbox");

            //Account Credential
            configMap.Add("acct1.UserName", "jb-us-seller_api1.paypal.com");
            configMap.Add("acct1.Password", "WX4WTU3S8MY44S7F");
            configMap.Add("acct1.Signature", "AFcWxV21C7fd0v3bYYYRCpSSRl31A7yDhhsPUU2XhtMoZXsWHFxu-RWy");
            configMap.Add("acct1.AppId", "APP-80W284485P519543T");

            //Sandbox Email Address
            configMap.Add("sandbox.EmailAddress", "pp.devtools@gmail.com");

            return configMap;
        }
	
        //Creates a configuration map containing certificate credentials and other required configuration parameters
        public static Dictionary<string, string> GetCertificateConfig()
        {
            Dictionary<string, string> configMap = new Dictionary<string, string>();

            //Endpoints are varied depending on whether sandbox OR live is chosen for mode
            configMap.Add("mode", "sandbox");

            //Account Credential
            configMap.Add("acct2.UserName", "certuser_biz_api1.paypal.com");
            configMap.Add("acct2.Password", "D6JNKKULHN3G5B8A");
            configMap.Add("acct2.CertKey", "password");
            configMap.Add("acct2.CertPath", "resource/sdk-cert.p12");
            configMap.Add("acct2.AppId", "APP-80W284485P519543T");


            //Sandbox Email Address
            configMap.Add("sandbox.EmailAddress", "pp.devtools@gmail.com");

            return configMap;
        }
    }
}
