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
    public partial class BMButtonSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            startDate.Text = DateTime.Now.AddDays(-5).ToString("yyyy-MM-ddTHH:mm:ss");
            endDate.Text = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        }
        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            if (calendar.ID.Equals("calStartDate"))
            {
                startDate.Text = calendar.SelectedDate.ToString("yyyy-MM-ddTHH:mm:ss");
            }
            else if (calendar.ID.Equals("calEndDate"))
            {
                endDate.Text = calendar.SelectedDate.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMButtonSearchRequestType request = new BMButtonSearchRequestType();
            request.StartDate = startDate.Text;
            request.EndDate = endDate.Text;

            // Invoke the API
            BMButtonSearchReq wrapper = new BMButtonSearchReq();
            wrapper.BMButtonSearchRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            BMButtonSearchResponseType response = service.BMButtonSearch(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMButtonSearchResponseType response)
        {
            HttpContext CurrContext = HttpContext.Current;
            CurrContext.Items.Add("Response_apiName", "BMButtonSearch");
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
                responseParams.Add("Matching results #", response.ButtonSearchResult.Count.ToString());
                for (int i = 0; i < response.ButtonSearchResult.Count; i++)
                {
                    String label = "Button " + (i + 1);
                    responseParams.Add(label + " type", response.ButtonSearchResult[i].ButtonType.ToString());
                    responseParams.Add(label + " item Name", response.ButtonSearchResult[i].ItemName);
                    if (response.ButtonSearchResult[i].HostedButtonID != null)
                    {
                        responseParams.Add(label + " Hosted button Id", response.ButtonSearchResult[i].HostedButtonID);
                    }
                }

                //Selenium Test Case
                responseParams.Add("Acknowledgement", response.Ack.ToString());
            }
            CurrContext.Items.Add("Response_keyResponseObject", responseParams);
            Server.Transfer("../APIResponse.aspx");

        }            
    }
}
