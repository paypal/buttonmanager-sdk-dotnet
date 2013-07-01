using System;
using System.Collections.Generic;
using System.Web;

using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using ButtonManagerAPISample;

namespace PayPalAPISample.APICalls
{
    public partial class BMSetInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMSetInventoryRequestType request = new BMSetInventoryRequestType();

            // (Required) The ID of the hosted button whose inventory you want to set.
            request.HostedButtonID = hostedID.Value;

            // (Required) Whether to track inventory levels associated with the button. 
            // It is one of the following values:
            // 0 - do not track inventory
            // 1 - track inventory
            request.TrackInv = trackInv.Value;

            // (Required) Whether to track the gross profit associated with inventory changes. 
            // It is one of the following values:
            //  0 - do not track the gross profit
            //  1 - track the gross profit
            //Note: The gross profit is calculated as the price of the item less its cost, 
            // multiplied by the change in the inventory level since the last call to BMSetInventory
            request.TrackPnl = trackPnl.Value;
            if (soldoutURL.Value != string.Empty)
            {
            //(Optional) The URL to which the buyer's browser is redirected when the inventory drops to 0.
            // Note: Specifying a URL in this field also prevents a sale when the inventory drops to 0; 
            // otherwise, sales can continue even when inventory is unavailable.
            // Character length and limitations: 127 single-byte alphanumeric characters
                request.SoldoutURL = soldoutURL.Value;
            }

            request.ItemTrackingDetails = new ItemTrackingDetailsType();
            if(itemNumber.Value != string.Empty)
            {
                // (Optional) The ID for an item associated with this button
                request.ItemTrackingDetails.ItemNumber = itemNumber.Value;
            }
            if (trackInv.Value == "1" && itemQty.Value != string.Empty)
            {
                // The quantity you want to specify for the item associated with this button. 
                // Specify either the absolute quantity in this field or the change in quantity in the quantity delta field
                request.ItemTrackingDetails.ItemQty = itemQty.Value;
            }
            if(trackPnl.Value == "1" && itemCost.Value != string.Empty)
            {
                // (Optional) The cost of the item associated with this button
                request.ItemTrackingDetails.ItemCost = itemCost.Value;
            }
            if(itemAlert.Value != string.Empty)
            {
                // (Optional) The quantity of the item associated with this button below which 
                // PayPal sends you an email notification
                request.ItemTrackingDetails.ItemAlert = itemAlert.Value;
            }

            // Invoke the API
            BMSetInventoryReq wrapper = new BMSetInventoryReq();
            wrapper.BMSetInventoryRequest = request;

            // Configuration map containing signature credentials and other required configuration.
            // For a full list of configuration parameters refer at 
            // (https://github.com/paypal/buttonmanager-sdk-dotnet/wiki/SDK-Configuration-Parameters)
            Dictionary<string, string> configurationMap = Configuration.GetSignatureConfig();

            // Creating service wrapper object to make an API call by loading configuration map. 
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(configurationMap);


            BMSetInventoryResponseType response = service.BMSetInventory(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMSetInventoryResponseType response)
        {
            HttpContext CurrContext = HttpContext.Current;
            CurrContext.Items.Add("Response_apiName", "BMSetInventory");
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
