using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Net;
using System.Web;
using System.Text;
using log4net;
using PayPal.Manager;
using PayPal.Authentication;
using PayPal.Exception;

namespace PayPal
{
    /// <summary>
    /// Calls the actual Platform API web service for the given Payload and APIProfile settings
    /// </summary>
    public class APIService
    {
        /// <summary>
        /// HTTP Method needs to be set.
        /// </summary>
        private const string RequestMethod = BaseConstants.REQUESTMETHOD;

        private static readonly ILog log = LogManager.GetLogger( typeof(APIService) );

        private static ArrayList retryCodes = new ArrayList(new HttpStatusCode[] 
                                                { HttpStatusCode.GatewayTimeout,
                                                  HttpStatusCode.RequestTimeout,
                                                  HttpStatusCode.InternalServerError,
                                                  HttpStatusCode.ServiceUnavailable,
                                                });

        private string serviceName;
        private string serviceVersion;

        public APIService(string serviceName, string serviceVersion)
        {
            this.serviceName = serviceName;
            this.serviceVersion = serviceVersion;
        }

        /// <summary>
        /// Calls the platform API web service for given payload and returns the response payload.
        /// </summary>
        /// <returns>returns the response payload</returns>
        public string MakeRequest(string method, string requestPayload, string apiUserName,
                                    string accessToken, string accessTokenSecret)
        {

            ConfigManager configMgr = ConfigManager.Instance;            
            string uri, responseString = string.Empty;
            AuthenticationHandler authHandler = new AuthenticationHandler(apiUserName);
            // Construct the URL to invoke
            if (configMgr.GetProperty("binding") != "SOAP")
            {
                uri = GetAPIEndpoint(method);
            }
            else
            {
                uri = configMgr.GetProperty("endpoint");
            }
            log.Debug("Connecting to " + uri);

            // Constructing HttpWebRequest object                
            ConnectionManager conn = ConnectionManager.Instance;            
            HttpWebRequest httpRequest = conn.GetConnection(uri);
            httpRequest.Method = RequestMethod;
            
            // Set up Headers            
            if(accessToken != null && accessTokenSecret != null)
            {
                authHandler.SetOAuthToken(accessToken, accessTokenSecret);
            }

            authHandler.SetAuthenticationParams(httpRequest, uri);
            if (configMgr.GetProperty("binding") == "SOAP")
            {
                requestPayload = authHandler.AppendSoapHeaders(requestPayload, accessToken, accessTokenSecret);
            }
            else
            {
                httpRequest.Headers.Add(BaseConstants.XPAYPALREQUESTDATAFORMAT, BaseConstants.RequestDataformat);
                httpRequest.Headers.Add(BaseConstants.XPAYPALRESPONSEDATAFORMAT, BaseConstants.ResponseDataformat);
                httpRequest.Headers.Add(BaseConstants.XPAYPALDEVICEIPADDRESS, configMgr.GetProperty("IPAddress"));
            }
            // Add tracking header           
            httpRequest.Headers.Add(BaseConstants.XPAYPALREQUESTSOURCE, 
                    BaseConstants.SDK_NAME + "-" + BaseConstants.SDK_VERSION);

            if (log.IsDebugEnabled)
            {
                foreach (string headerName in httpRequest.Headers)
                {
                    log.Debug(headerName + ":" + httpRequest.Headers[headerName]);
                }
            }
            // Adding payLoad to HttpWebRequest object
            try
            {
                using (StreamWriter myWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    myWriter.Write(requestPayload);
                    log.Debug(requestPayload);
                }
            }
            catch (WebException ex)
            {
                throw new ConnectionException(ex.Message);
            }

            // Fire request. Retry if configured to do so
            int numRetries = (configMgr.GetProperty("requestRetries") != null ) ? 
                int.Parse(configMgr.GetProperty("requestRetries")) : 0;
            int retries = 0;

            do
            {
                try
                {
                    // calling the plaftform API web service and getting the response
                    using (WebResponse response = httpRequest.GetResponse())
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                        {
                            responseString = sr.ReadToEnd();
                            log.Debug("Service response");
                            log.Debug(responseString);                                                  
                            return responseString;
                        }
                    }
                }
                // server responses in the range of 4xx and 5xx throw a WebException
                catch (WebException we)
                {
                    HttpStatusCode statusCode =  ( (HttpWebResponse) we.Response ).StatusCode;
                    
                    log.Info("Got " + statusCode.ToString() + " response from server");
                    if (!RequiresRetry(we))
                    {
                        throw new ConnectionException("Invalid HTTP response " + we.Message);
                    }
                }           
                catch (System.Exception ex)
                {                
                    throw ex;
                }
            } while ( retries++ < numRetries);

            throw new ConnectionException("Invalid HTTP response");
        }

        private string GetAPIEndpoint(string method)
        {
            // PayPal's APIs include the service method name as part of the URL
            ConfigManager configMgr = ConfigManager.Instance;
            return configMgr.GetProperty("endpoint") + this.serviceName + '/' + method;
        }

        /// <summary>
        /// returns true if a HTTP retry is required
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static bool RequiresRetry(WebException ex)
        {
            if (ex.Status != WebExceptionStatus.ProtocolError)
            {
                return false;
            }
            HttpStatusCode status = ((HttpWebResponse)ex.Response).StatusCode;
            return retryCodes.Contains(status); 
        }

    }


}
