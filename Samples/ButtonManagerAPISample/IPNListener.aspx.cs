using System;
using System.Web;
using System.Collections.Specialized;
using log4net;
using PayPal;
using System.Collections.Generic;

namespace ButtonManagerAPISample
{
    public partial class IPNListener : System.Web.UI.Page
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(IPNListener));

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                byte[] parameters = Request.BinaryRead(HttpContext.Current.Request.ContentLength);

                if (parameters.Length > 0)
                {

                    // Configuration map containing signature credentials and other required configuration.
                    // For a full list of configuration parameters refer at 
                    // (https://github.com/paypal/adaptivepayments-sdk-dotnet/wiki/SDK-Configuration-Parameters)
                    Dictionary<string, string> configurationMap = Configuration.GetSignatureConfig();
                    IPNMessage ipnListener = new IPNMessage(configurationMap, parameters);

                    bool isIpnValidated = ipnListener.Validate();
                    string transactionType = ipnListener.TransactionType;
                    NameValueCollection map = ipnListener.IpnMap;

                    logger.Info("----------Type-------------------" + this.GetType().Name + "\n"
                               + "*********IPN Name Value Pair****" + map + "\n"
                               + "#########IPN Transaction Type###" + transactionType + "\n"
                               + "=========IPN Validation=========" + isIpnValidated);
                }
            }
            catch (System.Exception ex)
            {
                logger.Debug("Exception in class " + this.GetType().Name + ": " + ex.Message);
                return;
            }
        }
    }
}
