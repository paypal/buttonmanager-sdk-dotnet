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
    public partial class BMSetInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMSetInventoryRequestType request = new BMSetInventoryRequestType();
            request.HostedButtonID = hostedID.Value;
            request.TrackInv = trackInv.Value;
            request.TrackPnl = trackPnl.Value;
            if (soldoutURL.Value != "")
            {
                request.SoldoutURL = soldoutURL.Value;
            }

            request.ItemTrackingDetails = new ItemTrackingDetailsType();
            if(itemNumber.Value != "")
            {
                request.ItemTrackingDetails.ItemNumber = itemNumber.Value;
            }
            if (trackInv.Value == "1" && itemQty.Value != "")
            {
                request.ItemTrackingDetails.ItemQty = itemQty.Value;
            }
            if(trackPnl.Value == "1" && itemCost.Value != "")
            {
                request.ItemTrackingDetails.ItemCost = itemCost.Value;
            }
            if(itemAlert.Value != "")
            {
                request.ItemTrackingDetails.ItemAlert = itemAlert.Value;
            }

            // Invoke the API
            BMSetInventoryReq wrapper = new BMSetInventoryReq();
            wrapper.BMSetInventoryRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
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
