using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using log4net;
using PayPal;

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
                    IPNMessage ipn = new IPNMessage(parameters);
                    bool isIpnValidated = ipn.Validate();
                    string transactionType = ipn.TransactionType;
                    NameValueCollection map = ipn.IpnMap;

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
