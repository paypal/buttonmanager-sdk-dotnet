using System;
using System.Collections.Generic;
using System.Text;
using PayPal.Authentication;

namespace PayPal
{
    public class BasePayPalService
    {       
        private string ServiceName;
        private string ServiceVersion;
        private string AccessToken;
        private string AccessTokenSecret;
        private string LastRequest;
        private string LastResponse;

        public BasePayPalService(string serviceName, string serviceVersion)
        {
            this.ServiceName = serviceName;
            this.ServiceVersion = serviceVersion;
        }

        public void setAccessToken(string accessToken)
        {
            this.AccessToken = accessToken;
        }

        public void setAccessTokenSecret(string accessTokenSecret)
        {
            this.AccessTokenSecret = accessTokenSecret;
        }

        public string getLastRequest()
        {
            return this.LastRequest;
        }

        public string getLastResponse()
        {
            return this.LastResponse;
        }

        /// <summary>
        /// Call method exposed to user
        /// </summary>
        /// <param name="method"></param>
        /// <param name="requestPayload"></param>
        /// <returns></returns>
        public string call(String method, string requestPayload, string apiUsername)
        {            
            APIService apiService = new APIService(ServiceName, ServiceVersion);
            this.LastRequest = requestPayload;
            this.LastResponse =  apiService.makeRequest(method, requestPayload, apiUsername, 
                                    this.AccessToken, this.AccessTokenSecret);
            return this.LastResponse;
        }
    }
}
