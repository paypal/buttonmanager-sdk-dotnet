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
    public partial class BMCreateButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["buttonCode"] != null)
            {
                buttonCode.SelectedValue = Request.Params["buttonCode"];
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMCreateButtonRequestType request = new BMCreateButtonRequestType();
            ButtonTypeType selectedButtonType = (ButtonTypeType)
                Enum.Parse(typeof(ButtonTypeType), buttonType.SelectedValue);
            request.ButtonType = selectedButtonType;
            request.ButtonCode = (ButtonCodeType)
                Enum.Parse(typeof(ButtonCodeType), buttonCode.SelectedValue);


            /* Add HTML standard button variables that control what is posted to 
             * PayPal when a user clicks on the created button. Refer the
             * "HTML Variables for Website Payments Standard" guide for more.
             */
            List<String> buttonVars = new List<String>();
            buttonVars.Add("item_name=" + itemName.Value);
            buttonVars.Add("return=" + returnURL.Value);
            buttonVars.Add("business=" + businessMail.Value);
            buttonVars.Add("amount=" + amount.Value);
            request.ButtonVar = buttonVars;

            /* Construct rest of the request values according to the buttontype 
             * that the user chose. Consult the ButtonManager documentation
             * for a complete list of supported arguments for the different
             * button types 
             */
            if (selectedButtonType.Equals(ButtonTypeType.PAYMENTPLAN))
            {      
                InstallmentDetailsType insType = new InstallmentDetailsType();
                insType.TotalBillingCycles = Int32.Parse(billingCycles.Value);
                insType.Amount = installmentAmt.Value;
                insType.BillingFrequency = Int32.Parse(billingFreq.Value);
                insType.BillingPeriod = (BillingPeriodType)
                        Enum.Parse(typeof(BillingPeriodType), billingPeriod.SelectedValue);
                List<InstallmentDetailsType> insList = new List<InstallmentDetailsType>();
                insList.Add(insType);

                OptionSelectionDetailsType detailsType = new OptionSelectionDetailsType("CreateButton");
                detailsType.OptionType = (OptionTypeListType)
                    Enum.Parse(typeof(OptionTypeListType), optionType.SelectedValue);
                detailsType.PaymentPeriod = insList;

                List<OptionSelectionDetailsType> optSelectList = new List<OptionSelectionDetailsType>();
                optSelectList.Add(detailsType);

                OptionDetailsType optType = new OptionDetailsType("CreateButton");
                optType.OptionSelectionDetails = optSelectList;

                List<OptionDetailsType> optList = new List<OptionDetailsType>();
                optList.Add(optType);

                request.OptionDetails = optList;

            }
            else if (selectedButtonType.Equals(ButtonTypeType.AUTOBILLING))
            {
                buttonVars.Add("min_amount=" + minAmt.Value);
            }
            else if (selectedButtonType.Equals(ButtonTypeType.GIFTCERTIFICATE))
            {
                buttonVars.Add("shopping_url=" + shoppingUrl.Value);
            } 
            else if (selectedButtonType.Equals(ButtonTypeType.PAYMENT))
            {
                buttonVars.Add("subtotal=" + subTotal.Value);
            }
            else if (selectedButtonType.Equals(ButtonTypeType.SUBSCRIBE))
            {
                buttonVars.Add("a3=" + subAmt.Value);
                buttonVars.Add("p3=" + subPeriod.Value);
                buttonVars.Add("t3=" + subInterval.SelectedValue);
            }


            // Invoke the API
            BMCreateButtonReq wrapper = new BMCreateButtonReq();
            wrapper.BMCreateButtonRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            BMCreateButtonResponseType response = service.BMCreateButton(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMCreateButtonResponseType response)
        {
            HttpContext CurrContext = HttpContext.Current;
            CurrContext.Items.Add("Response_apiName", "BMCreateButton");
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
                if (response.HostedButtonID != null)
                {
                    responseParams.Add("Hosted button ID", response.HostedButtonID);
                }
                if (response.Website != null)
                {
                    responseParams.Add("Generated button", response.Website);
                    responseParams.Add("Website HTML code", HttpUtility.HtmlEncode(response.Website));
                }
                if (response.Email != "")
                {
                    responseParams.Add("Code for email links", response.Email);
                }

                //Selenium Test Case
                responseParams.Add("Acknowledgement", response.Ack.ToString());
            }
            CurrContext.Items.Add("Response_keyResponseObject", responseParams);
            Server.Transfer("../APIResponse.aspx");

        }            

    }
}
