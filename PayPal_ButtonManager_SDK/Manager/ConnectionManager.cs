using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using log4net;

using PayPal.Authentication;
using PayPal.Exception;

namespace PayPal.Manager
{
    public class ConnectionManager
    {
        private static ILog logger = LogManager.GetLogger(typeof(ConnectionManager));

        /// <summary>
        /// Singleton instance of ConnectionManager
        /// </summary>
        private static readonly ConnectionManager instance = new ConnectionManager();
        public static ConnectionManager Instance
        {
            get
            {
                return instance;
            }
        }

        private ConnectionManager()
        {}

        /// <summary>
        /// Create and Config a HttpWebRequest
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public HttpWebRequest getConnection(string url)
        {

            ConfigManager configMgr = ConfigManager.Instance;
            HttpWebRequest httpRequest;
                        
            try
            {
                httpRequest = (HttpWebRequest)WebRequest.Create(url);
            }
            catch (UriFormatException ex)
            {
                logger.Debug(ex.Message);
                throw new ConfigException("Invalid URI " + url);
            }

            // Set connection timeout
            //TODO: handle parse exception
            int ConnectionTimeout = Int32.Parse(configMgr.GetProperty("connectionTimeout"));
            if (ConnectionTimeout < 1)
                ConnectionTimeout = BaseConstants.DEFAULT_TIMEOUT;
            httpRequest.Timeout = ConnectionTimeout;

            // Set request proxy for tunnelling http requests via a proxy server
            string proxyAddress = configMgr.GetProperty("proxyAddress");
            if (proxyAddress != null)
            {
                WebProxy requestProxy = new WebProxy();
                requestProxy.Address = new Uri(proxyAddress);

                string proxyCredentials = configMgr.GetProperty("proxyCredentials");
                if (proxyCredentials != null)
                {
                    string[] proxyDetails = proxyCredentials.Split(':');
                    if (proxyDetails.Length == 2)
                    {
                        requestProxy.Credentials = new NetworkCredential(proxyDetails[0], proxyDetails[1]);
                    }
                }                
                httpRequest.Proxy = requestProxy;
            }

            return httpRequest;
        }
    }
}
