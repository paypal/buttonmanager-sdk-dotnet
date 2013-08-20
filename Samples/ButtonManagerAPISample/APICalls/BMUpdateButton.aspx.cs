using System;
using System.Collections.Generic;
using System.Web;

using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;
using ButtonManagerAPISample;

namespace PayPalAPISample.APICalls
{
    public partial class BMUpdateButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Create request object
            BMUpdateButtonRequestType request = new BMUpdateButtonRequestType();

            // (Required) The kind of button you want to update. It is one of the following values:
            //    BUYNOW - Buy Now button
            //    CART - Add to Cart button
            //    GIFTCERTIFICATE - Gift Certificate button
            //    SUBSCRIBE - Subscribe button
            //    DONATE - Donate button
            //    UNSUBSCRIBE - Unsubscribe button
            //    VIEWCART - View Cart button
            //    PAYMENTPLAN - Installment Plan button; since version 63.0
            //    AUTOBILLING - Automatic Billing button; since version 63.0
            // Note:
            // You cannot change the kind of button after the button has been created.
            ButtonTypeType selectedButtonType = (ButtonTypeType)
                Enum.Parse(typeof(ButtonTypeType), buttonType.SelectedValue);
            request.ButtonType = selectedButtonType;

            //(Optional) The kind of button code to create. It is one of the following values:
            // HOSTED - A secure button stored on PayPal; default for all buttons except View Cart 
            // and Unsubscribe
            // ENCRYPTED - An encrypted button, not stored on PayPal; default for View Cart button
            // CLEARTEXT - An unencrypted button, not stored on PayPal; default for Unsubscribe button
            // Note:
            // You cannot change the kind of button code after after the button has been created.
            request.ButtonCode = (ButtonCodeType)
                Enum.Parse(typeof(ButtonCodeType), buttonCode.SelectedValue);

            //Selenium Test Case
            //(Required) The ID of the hosted button you want to modify.
            request.HostedButtonID = hostedID.Value.ToString();

            /* Add HTML standard button variables that control what is posted to 
             * PayPal when a user clicks on the created button. Refer the
             * "HTML Variables for Website Payments Standard" guide for more.
             */
            List<string> buttonVars = new List<string>();
            buttonVars.Add("item_name=" + itemName.Value);
            buttonVars.Add("return=" + returnURL.Value);
            buttonVars.Add("business=" + businessMail.Value);
            buttonVars.Add("amount=" + amount.Value);
            buttonVars.Add("notify_url=" +  notifyURL.Value.Trim());

            request.ButtonVar = buttonVars;

            /* Construct rest of the request values according to the buttontype 
             * that the user chose. Consult the ButtonManager documentation
             * for a complete list of supported arguments for the different
             * button types 
             */
            if (selectedButtonType.Equals(ButtonTypeType.PAYMENTPLAN))
            {
                InstallmentDetailsType insType = new InstallmentDetailsType();

                //(Optional) The total number of billing cycles, 
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
                //  FULL - Payment in full
                //  VARIABLE - Variable installments
                //  EMI - Equal installments
                // Note:
                // Only available for Installment Plan buttons.
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
                //It is a list of variables, in which n is a digit between 0 and 999, 
                // inclusive; do not include leading zeros.
                //Character length and limitations: 63 single-byte alphanumeric characters each
                buttonVars.Add("min_amount=" + minAmt.Value);
            }
            else if (selectedButtonType.Equals(ButtonTypeType.GIFTCERTIFICATE))
            {
                //(Optional) HTML standard button variables
                //It is a list of variables, in which n is a digit between 0 and 999, 
                // inclusive; do not include leading zeros.
                //Character length and limitations: 63 single-byte alphanumeric characters each
                buttonVars.Add("shopping_url=" + shoppingUrl.Value);
            }
            else if (selectedButtonType.Equals(ButtonTypeType.PAYMENT))
            {
                // (Optional) HTML standard button variables
                //It is a list of variables, in which n is a digit between 0 and 999, 
                // inclusive; do not include leading zeros.
                //Character length and limitations: 63 single-byte alphanumeric characters each
                buttonVars.Add("subtotal=" + subTotal.Value);
            }
            else if (selectedButtonType.Equals(ButtonTypeType.SUBSCRIBE))
            {
                // (Optional) HTML standard button variables
                //It is a list of variables, in which n is a digit between 0 and 999, 
                // inclusive; do not include leading zeros.
                //Character length and limitations: 63 single-byte alphanumeric characters each
                buttonVars.Add("a3=" + subAmt.Value);
                buttonVars.Add("p3=" + subPeriod.Value);
                buttonVars.Add("t3=" + subInterval.SelectedValue);
            }


            // Invoke the API
            BMUpdateButtonReq wrapper = new BMUpdateButtonReq();
            wrapper.BMUpdateButtonRequest = request;

            // Configuration map containing signature credentials and other required configuration.
            // For a full list of configuration parameters refer in wiki page 
            // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
            Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

            // Creating service wrapper object to make an API call by loading configuration map. 
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService(configurationMap);

            BMUpdateButtonResponseType response = service.BMUpdateButton(wrapper);

            // Check for API return status
            setKeyResponseObjects(service, response);
        }

        private void setKeyResponseObjects(PayPalAPIInterfaceServiceService service, BMUpdateButtonResponseType response)
        {
            HttpContext CurrContext = HttpContext.Current;
            CurrContext.Items.Add("Response_apiName", "BMUpdateButton");
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
                    // (Required) The ID of the hosted button you want to modify.
                    responseParams.Add("Hosted button ID", response.HostedButtonID);
                }
                if (response.Website != null)
                {
                    // HTML code for web pages
                    responseParams.Add("Generated button", response.Website);
                    responseParams.Add("Website HTML code", HttpUtility.HtmlEncode(response.Website));
                }
                if (response.Email != string.Empty)
                {
                    // Code for email links and links in other documents that support external links
                    responseParams.Add("Code for email links", response.Email);
                }
            }
            CurrContext.Items.Add("Response_keyResponseObject", responseParams);
            Server.Transfer("../APIResponse.aspx");

        }            

    }
}
