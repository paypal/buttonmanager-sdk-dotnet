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

using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;

namespace PayPalAPISample.APICalls
{
    public partial class BMGetButtonDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMGetButtonDetailsRequestType request = new BMGetButtonDetailsRequestType();
            request.HostedButtonID = hostedID.Value;

            // Invoke the API
            BMGetButtonDetailsReq wrapper = new BMGetButtonDetailsReq();
            wrapper.BMGetButtonDetailsRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            BMGetButtonDetailsResponseType response = service.BMGetButtonDetails(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMGetButtonDetailsResponseType response)
        {
            Session["Response_apiName"] = "BMGetButtonDetails";
            Session["Response_redirectURL"] = null;
            Session["Response_requestPayload"] = service.getLastRequest();
            Session["Response_responsePayload"] = service.getLastResponse();

            Dictionary<string, string> responseParams = new Dictionary<string, string>();
            responseParams.Add("Correlation Id", response.CorrelationID);
            responseParams.Add("API Result", response.Ack.ToString());

            if (response.Ack.Equals(AckCodeType.FAILURE) ||
                (response.Errors != null && response.Errors.Count > 0))
            {
                Session["Response_error"] = response.Errors;
            }
            else
            {
                Session["Response_error"] = null;
                responseParams.Add("Button type", response.ButtonType.ToString());
                responseParams.Add("Button code", response.ButtonCode.ToString());
                for( int i=0; i<response.ButtonVar.Count; i++) 
                {
                    responseParams.Add("Button var " + (i+1), response.ButtonVar[i]);
                }
            }
            Session["Response_keyResponseObject"] = responseParams;
            Response.Redirect("../APIResponse.aspx");
        }
    }
}
