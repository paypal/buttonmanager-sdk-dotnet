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
    public partial class BMGetInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMGetInventoryRequestType request = new BMGetInventoryRequestType();
            request.HostedButtonID = hostedID.Value;

            // Invoke the API
            BMGetInventoryReq wrapper = new BMGetInventoryReq();
            wrapper.BMGetInventoryRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            BMGetInventoryResponseType response = service.BMGetInventory(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMGetInventoryResponseType response)
        {
            Session["Response_apiName"] = "BMGetInventory";
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
                responseParams.Add("Is inventory tracked", response.TrackInv);
                responseParams.Add("Is Profit & Loss tracked", response.TrackPnl);
                responseParams.Add("Item Number", response.ItemTrackingDetails.ItemNumber);
                responseParams.Add("Item Quantity", response.ItemTrackingDetails.ItemQty);
                responseParams.Add("Item Cost", response.ItemTrackingDetails.ItemCost);
                responseParams.Add("Item Alert threshold quantity", response.ItemTrackingDetails.ItemAlert);
                responseParams.Add("Soldout URL", response.SoldoutURL);
            }
            Session["Response_keyResponseObject"] = responseParams;
            Response.Redirect("../APIResponse.aspx");
        }
    }
}
