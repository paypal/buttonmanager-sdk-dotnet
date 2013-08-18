using System;
using System.Collections.Generic;
using System.Web;

using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using ButtonManagerAPISample;

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

            // (Required) The ID of the hosted button whose status you want to change.
            request.HostedButtonID = hostedID.Value;

            //(Required) The new status of the button. It is one of the following values:
            //DELETE - the button is deleted from PayPal
            request.ButtonStatus = (ButtonStatusType)
                Enum.Parse(typeof(ButtonStatusType), buttonStatus.SelectedValue);

            // Invoke the API
            BMManageButtonStatusReq wrapper = new BMManageButtonStatusReq();
            wrapper.BMManageButtonStatusRequest = request;

            // Configuration map containing signature credentials and other required configuration.
            // For a full list of configuration parameters refer at 
            // (https://github.com/paypal/buttonmanager-sdk-dotnet/wiki/SDK-Configuration-Parameters)
            Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

            // Creating service wrapper object to make an API call by loading configuration map. 
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(configurationMap);

            BMManageButtonStatusResponseType response = service.BMManageButtonStatus(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMManageButtonStatusResponseType response)
        {
            HttpContext CurrContext = HttpContext.Current;
            CurrContext.Items.Add("Response_apiName", "BMManageButtonStatus");
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
            }
            CurrContext.Items.Add("Response_keyResponseObject", responseParams);
            Server.Transfer("../APIResponse.aspx");
        }

    }
}
