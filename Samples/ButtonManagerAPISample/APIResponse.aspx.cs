using System;
using System.Collections.Generic;
using System.Web;

using PayPal.PayPalAPIInterfaceService.Model;

namespace PayPalAPISample
{
    public partial class APIResponse : System.Web.UI.Page
    {
        private string m_apiName;
        protected string apiName
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

        protected string m_redirectURL;
        protected string redirectURL
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
            if (!IsPostBack)
            {
                HttpContext CurrContext = HttpContext.Current;
                if (CurrContext.Items["Response_keyResponseObject"] != null)
                {
                    responseValues = (Dictionary<string, string>)CurrContext.Items["Response_keyResponseObject"];
                }
                if (CurrContext.Items["Response_apiName"] != null)
                {
                    apiName = (string)CurrContext.Items["Response_apiName"];
                }
                if (CurrContext.Items["Response_redirectURL"] != null)
                {
                    redirectURL = (string)CurrContext.Items["Response_redirectURL"];
                }
                if (CurrContext.Items["Response_requestPayload"] != null)
                {
                    requestMessage = (string)CurrContext.Items["Response_requestPayload"];
                }
                if (CurrContext.Items["Response_responsePayload"] != null)
                {
                    responseMessage = (string)CurrContext.Items["Response_responsePayload"];
                }
                if (CurrContext.Items["Response_error"] != null)
                {
                    errorMessages = (List<ErrorType>)CurrContext.Items["Response_error"];
                }
            }
        }
    }
}
