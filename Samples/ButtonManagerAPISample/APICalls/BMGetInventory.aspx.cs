using System;
using System.Collections.Generic;
using System.Web;

using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using ButtonManagerAPISample;

namespace PayPalAPISample.APICalls
{
    public partial class BMGetInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMGetInventoryRequestType request = new BMGetInventoryRequestType();

            //(Required) The ID of the hosted button whose inventory information you want to obtain.
            request.HostedButtonID = hostedID.Value;

            // Invoke the API
            BMGetInventoryReq wrapper = new BMGetInventoryReq();
            wrapper.BMGetInventoryRequest = request;

            // Configuration map containing signature credentials and other required configuration.
            // For a full list of configuration parameters refer at 
            // (https://github.com/paypal/buttonmanager-sdk-dotnet/wiki/SDK-Configuration-Parameters)
            Dictionary<string, string> configurationMap = Configuration.GetSignatureConfig();

            // Creating service wrapper object to make an API call by loading configuration map. 
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(configurationMap);
            BMGetInventoryResponseType response = service.BMGetInventory(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMGetInventoryResponseType response)
        {
            HttpContext CurrContext = HttpContext.Current;
            CurrContext.Items.Add("Response_apiName", "BMGetInventory");
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

                // Whether to track inventory levels associated with the button. 
                // It is one of the following values:
                // 0 - do not track inventory
                // 1 - track inventory
                responseParams.Add("Is inventory tracked", response.TrackInv);

                // Whether to track the gross profit associated with inventory changes. 
                // It is one of the following values:
                //    0 - do not track the gross profit
                //    1 - track the gross profit
                // Note:
                // The gross profit is calculated as the price of the item less its cost, 
                // multiplied by the change in the inventory level since the last call to BMSetInventory.
                responseParams.Add("Is Profit & Loss tracked", response.TrackPnl);

                // The ID for an item associated with this button 
                responseParams.Add("Item Number", response.ItemTrackingDetails.ItemNumber);

                // The current inventory level of the item associated with this button 
                responseParams.Add("Item Quantity", response.ItemTrackingDetails.ItemQty);

                // The cost of the item associated with this button 
                responseParams.Add("Item Cost", response.ItemTrackingDetails.ItemCost);

                // The quantity of the item associated with this button below which PayPal sends you an email notification 
                responseParams.Add("Item Alert threshold quantity", response.ItemTrackingDetails.ItemAlert);
                responseParams.Add("Soldout URL", response.SoldoutURL);
            }
            CurrContext.Items.Add("Response_keyResponseObject", responseParams);
            Server.Transfer("../APIResponse.aspx");
        }
    }
}
