using System;
using System.Collections.Generic;
using System.Web;

using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using ButtonManagerAPISample;

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

            //  (Required) The kind of button you want to create. It is one of the following values:
            //    BUYNOW - Buy Now button
            //    CART - Add to Cart button
            //    GIFTCERTIFICATE - Gift Certificate button
            //    SUBSCRIBE - Subscribe button
            //    DONATE - Donate button
            //    UNSUBSCRIBE - Unsubscribe button
            //    VIEWCART - View Cart button
            //    PAYMENTPLAN - Installment Plan button; since version 63.0
            //    AUTOBILLING - Automatic Billing button; since version 63.0
            //    PAYMENT - Pay Now button; since version 65.1
            // Note: Do not specify BUYNOW if BUTTONCODE=TOKEN; specify PAYMENT instead. 
            // Do not specify PAYMENT if BUTTONCODE=HOSTED. 
            ButtonTypeType selectedButtonType = (ButtonTypeType)
                Enum.Parse(typeof(ButtonTypeType), buttonType.SelectedValue);
            request.ButtonType = selectedButtonType;

            // (Optional) The kind of button code to create. It is one of the following values:
            // HOSTED - A secure button stored on PayPal; default for all buttons except View Cart, Unsubscribe, and Pay Now
            // ENCRYPTED - An encrypted button, not stored on PayPal; default for View Cart button
            // CLEARTEXT - An unencrypted button, not stored on PayPal; default for Unsubscribe button
            // TOKEN - A secure button, not stored on PayPal, used only to initiate the Hosted Solution checkout flow; 
            // default for Pay Now button. Since version 65.1
            request.ButtonCode = (ButtonCodeType)
                Enum.Parse(typeof(ButtonCodeType), buttonCode.SelectedValue);


            /* Add HTML standard button variables that control what is posted to 
             * PayPal when a user clicks on the created button. Refer the
             * "HTML Variables for Website Payments Standard" guide for more.
             */
            List<string> buttonVars = new List<string>();
            buttonVars.Add("item_name=" + itemName.Value);
            buttonVars.Add("return=" + returnURL.Value);
            buttonVars.Add("business=" + businessMail.Value);
            buttonVars.Add("notify_url=" + notifyURL.Value.Trim());
            request.ButtonVar = buttonVars;

            /* Construct rest of the request values according to the buttontype 
             * that the user chose. Consult the ButtonManager documentation
             * for a complete list of supported arguments for the different
             * button types 
             */
            if (selectedButtonType.Equals(ButtonTypeType.PAYMENTPLAN))
            {      
                InstallmentDetailsType insType = new InstallmentDetailsType();

                // (Optional) The total number of billing cycles, 
                // regardless of the duration of a cycle; 1 is the default
                insType.TotalBillingCycles = Convert.ToInt32(billingCycles.Value);

                // (Optional) The base amount to bill for the cycle.
                insType.Amount = installmentAmt.Value;

                // (Optional) The installment cycle frequency in units, e.g. 
                // if the billing frequency is 2 and the billing period is Month, 
                // the billing cycle is every 2 months. The default billing frequency is 1.
                insType.BillingFrequency = Convert.ToInt32(billingFreq.Value);

                 //(Optional) The installment cycle unit, which is one of the following values:
                 //   NoBillingPeriodType - None (default)
                 //   Day
                 //   Week
                 //   SemiMonth
                 //   Month
                 //   Year
                insType.BillingPeriod = (BillingPeriodType)
                        Enum.Parse(typeof(BillingPeriodType), billingPeriod.SelectedValue);
                List<InstallmentDetailsType> insList = new List<InstallmentDetailsType>();
                insList.Add(insType);

                OptionSelectionDetailsType detailsType = new OptionSelectionDetailsType("CreateButton");

                // (Optional) The installment option type for an OPTIONnNAME, 
                // which is one of the following values:
                // FULL - Payment in full
                // VARIABLE - Variable installments
                // EMI - Equal installments
                detailsType.OptionType = (OptionTypeListType)
                    Enum.Parse(typeof(OptionTypeListType), optionType.SelectedValue);

                // (Optional) Information about an installment option
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
                // (Optional) HTML standard button variables
                buttonVars.Add("min_amount=" + minAmt.Value);
            }
            else if (selectedButtonType.Equals(ButtonTypeType.GIFTCERTIFICATE))
            {
                // (Optional) HTML standard button variables
                buttonVars.Add("shopping_url=" + shoppingUrl.Value);
            } 
            else if (selectedButtonType.Equals(ButtonTypeType.PAYMENT))
            {

                // (Optional) HTML standard button variables
                buttonVars.Add("subtotal=" + subTotal.Value);
            }
            else if (selectedButtonType.Equals(ButtonTypeType.SUBSCRIBE))
            {

                // (Optional) HTML standard button variables
                buttonVars.Add("a3=" + subAmt.Value);
                buttonVars.Add("p3=" + subPeriod.Value);
                buttonVars.Add("t3=" + subInterval.SelectedValue);
            }


            // Invoke the API
            BMCreateButtonReq wrapper = new BMCreateButtonReq();
            wrapper.BMCreateButtonRequest = request;

            // Configuration map containing signature credentials and other required configuration.
            // For a full list of configuration parameters refer at 
            // (https://github.com/paypal/buttonmanager-sdk-dotnet/wiki/SDK-Configuration-Parameters)
            Dictionary<string, string> configurationMap = Configuration.GetSignatureConfig();

            // Creating service wrapper object to make an API call by loading configuration map. 
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(configurationMap);
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
                if (response.HostedButtonID != null)
                {
                    // ID of a PayPal-hosted button or a Hosted Solution token
                    responseParams.Add("Hosted button ID", response.HostedButtonID);
                }
                if (response.Website != null)
                {
                    responseParams.Add("Generated button", response.Website);
                    responseParams.Add("Website HTML code", HttpUtility.HtmlEncode(response.Website));
                }
                if (response.Email != string.Empty)
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
