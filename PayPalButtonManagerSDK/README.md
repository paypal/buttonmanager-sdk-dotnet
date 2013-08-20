


# PayPal Button Manager SDK

The PayPal Button Manager API helps you to dynamically create, manage, and edit large numbers of PayPal Payments Standard buttons. The PayPal Button Manager SDK provides the following methods:


   * BMButtonSearch: Use the BMButtonSearch API operation to obtain a list of your hosted Website Payments Standard buttons.
   * BMCreateButton: Use the BMCreateButton API operation to create a Website Payments Standard button.
   * BMGetButtonDetails: Use the BMGetButtonDetails API operation to obtain information about a hosted Website Payments Standard button.
   * BMGetInventory: Use the BMGetInventory API operation to determine the inventory levels and other inventory-related information for a button and menu items associated with the button.
   * BMManageButtonStatus: Use the BMManageButtonStatus API operation to change the status of a hosted button. Currently, you can only delete a button.
   * BMSetInventory: Use the BMSetInventory API operation to set the inventory level and inventory management features for the specified button.
   * BMUpdateButton: Use the BMUpdateButton API operation to modify a Website Payments Standard button that is hosted on PayPal.


## Prerequisites

   * Visual Studio 2005 or higher
   * .NET Framework 2.0 or higher
   * (Optional) NuGet 2.2 for managing dependencies

## Using the SDK

   To use the SDK in your application, you must
   
   * Get the PayPalButtonManagerSDK dll via NuGet or from the download bundle and add references to the PayPalButtonManagerSDK and PayPalCoreSDK libraries.
   * Configure your app as detailed in the configuration section.
   
## SDK Configuration

  An application that uses the PayPal SDKs can be configured in one of two ways -
  
  * Using the Web.Config / App.Config files.

	```html
    <configSections>
	<section name="paypal" type="PayPal.Manager.SDKConfigHandler, PayPalCoreSDK" />
	<section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
	</configSections>
	<!-- PayPal SDK config -->
	<paypal>
	<settings>
	    <add name="mode" value="sandbox"/>
	    <add name="connectionTimeout" value="30000"/>
	    .....
	</settings>
	<accounts>
	    <account apiUsername="jb-us-seller_api1.paypal.com" apiPassword="..." apiSignature="..."/>
	    <account apiUsername="enduser_biz_api1.gmail.com" apiPassword="..." apiCertificate="..." privateKeyPassword="..."/>
	</accounts>
	</paypal>
    ```
  
  * Or, by dynamically passing in a dictionary (that you can load from a database or as suits your needs).

    ```csharp
    Dictionary<string, string> config = new Dictionary<string, string>();
    config.Add("mode", "sandbox");
    config.Add("account1.apiUsername", "jb-us-seller_api1.paypal.com");
    config.Add("account1.apiPassword", "...");
    config.Add("account1.apiSignature", "...");

    PayPalAPIInterfaceServiceService service = new  PayPalAPIInterfaceServiceService(config);
    ```

	You can refer full list of configuration parameters in [wiki](https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters) page.
	
## Links

   * [Installing NuGet in Visual Studio 2005 & 2008] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2005-&-2008)
   * [Installing NuGet in Visual Studio 2010 & 2012] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2010-&-2012)
