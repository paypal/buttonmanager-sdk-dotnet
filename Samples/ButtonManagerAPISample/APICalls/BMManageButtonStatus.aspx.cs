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
    public partial class BMManageButtonStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMManageButtonStatusRequestType request = new BMManageButtonStatusRequestType();
            request.HostedButtonID = hostedID.Value;
            request.ButtonStatus = (ButtonStatusType)
                Enum.Parse(typeof(ButtonStatusType), buttonStatus.SelectedValue);

            // Invoke the API
            BMManageButtonStatusReq wrapper = new BMManageButtonStatusReq();
            wrapper.BMManageButtonStatusRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            BMManageButtonStatusResponseType response = service.BMManageButtonStatus(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMManageButtonStatusResponseType response)
        {
            Session["Response_apiName"] = "BMManageButtonStatus";
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
            }
            Session["Response_keyResponseObject"] = responseParams;
            Response.Redirect("../APIResponse.aspx");
        }

    }
}
