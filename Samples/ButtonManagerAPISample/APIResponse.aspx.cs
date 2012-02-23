using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using PayPal.PayPalAPIInterfaceService.Model;

namespace PayPalAPISample
{
    public partial class APIResponse : System.Web.UI.Page
    {
        private String m_apiName;
        protected String apiName
        {
            get
            {
                return m_apiName;
            }
            set
            {
                m_apiName = value;
            }
        }

        protected String m_redirectURL;
        protected String redirectURL
        {
            get
            {
                return m_redirectURL;
            }
            set
            {
                m_redirectURL = value;
            }
        }

        protected Dictionary<string, string> m_responseValues = new Dictionary<string,string>();
        protected Dictionary<string, string> responseValues
        {
            get
            {
                return m_responseValues;
            }
            set
            {
                m_responseValues = value;
            }
        }

        protected string m_requestMessage;
        public string requestMessage
        {
            get
            {
                return m_requestMessage;
            }
            set
            {
                m_requestMessage = value;
            }
        }

        protected string m_responseMessage;
        public string responseMessage
        {
            get
            {
                return m_responseMessage;
            }
            set
            {
                m_responseMessage = value;
            }
        }

        protected List<ErrorType> m_errorMessages;
        public List<ErrorType> errorMessages
        {
            get
            {
                return m_errorMessages;
            }
            set
            {
                m_errorMessages = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Response_keyResponseObject"] != null)
            {
                responseValues = (Dictionary<string, string>)Session["Response_keyResponseObject"];
            }
            if (Session["Response_apiName"] != null)
            {
                apiName = (String) Session["Response_apiName"];
            }
            if (Session["Response_redirectURL"] != null)
            {
                redirectURL = (String) Session["Response_redirectURL"];
            }
            if (Session["Response_requestPayload"] != null)
            {
                requestMessage = (String) Session["Response_requestPayload"];
            }
            if (Session["Response_responsePayload"] != null)
            {
                responseMessage = (String) Session["Response_responsePayload"];
            }
            if (Session["Response_error"] != null)
            {
                errorMessages = (List<ErrorType>)Session["Response_error"];
            }
        }
    }
}
