using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
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

            // (Required) The ID of the hosted button whose details you want to obtain.
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
            HttpContext CurrContext = HttpContext.Current;
            CurrContext.Items.Add("Response_apiName", "BMGetButtonDetails");
            CurrContext.Items.Add("Response_redirectURL", null);
            CurrContext.Items.Add("Response_requestPayload", service.getLastRequest());
            CurrContext.Items.Add("Response_responsePayload", service.getLastResponse());

            Dictionary<string, string> responseParams = new Dictionary<string, string>();
            // Correlation ID; it is used only by Developer Technical Support.
            // Note:
            // You must log and store this data for every response you receive. 
            // PayPal Technical Support uses the information to assist with reported issues.
            responseParams.Add("Correlation Id", response.CorrelationID);
            responseParams.Add("API Result", response.Ack.ToString());

            if (response.Ack.Equals(AckCodeType.FAILURE) ||
                (response.Errors != null && response.Errors.Count > 0))
            {
                CurrContext.Items.Add("Response_error", response.Errors);
            }
            else
            {
                CurrContext.Items.Add("Response_error", null);

                // The kind of button. It is one of the following values:
                //BUYNOW - Buy Now button
                //CART - Add to Cart button
                //GIFTCERTIFICATE - Gift Certificate button
                //SUBSCRIBE - Subscribe button
                //DONATE - Donate button
                //UNSUBSCRIBE - Unsubscribe button
                //VIEWCART - View Cart button
                //PAYMENTPLAN - Installment Plan button; since version 63.0
                //AUTOBILLING - Automatic Billing button; since version 63.0
                responseParams.Add("Button type", response.ButtonType.ToString());

                // The kind of button code. It is one of the following values:
                //HOSTED - A secure button stored on PayPal
                //ENCRYPTED - An encrypted button, not stored on PayPal
                //CLEARTEXT - An unencrypted button, not stored on PayPal
                responseParams.Add("Button code", response.ButtonCode.ToString());
                for( int i=0; i<response.ButtonVar.Count; i++) 
                {
                    // HTML standard button variables
                    responseParams.Add("Button var " + (i+1), response.ButtonVar[i]);
                }
            }
            CurrContext.Items.Add("Response_keyResponseObject", responseParams);
            Server.Transfer("../APIResponse.aspx");
        }
    }
}
