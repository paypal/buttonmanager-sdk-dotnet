
PayPal Button Manager SDK for .NET
==================================

	The PayPal Button Manager SDK allows .NET developers to invoke "PayPal Button Manager API's. 
While the API is described through a publicly available WSDL document and can be invoked directly, 
this SDK eases the development process by handling some of the plumbing code such as authentication, 
HTTP request processing etc.

Contents 
--------

	The SDK download comes as a Visual Studio solution that contains 

		1. the PayPal Button Manager SDK project, and 
		2. a sample C# web application that demonstrates use of the SDK. 
	
Please refer to the readme file under the sample project to understand how the sample application
can be run.


Prerequisites
-------------

   1. Microsoft .NET framework 2.0
   2. Microsoft Visual Studio 2005 Standard edition


Using the SDK
-------------

	To use the SDK in your application, you must do the following
	
	1. Create a Business/Personal account as appropriate and obtain API credentials from your
	   account profile.
	2. Add the PayPal_ButtonManager_SDK.dll file as a reference to your project.	   
	3. Configure the SDK through the Web.Config or App.Config file. You can refer to the config
	   file available in the sample.
	4. Invoke an api method using a similar code snippet
	
			// Create request object and set request parameters
	            BMCreateButtonRequestType request = new BMCreateButtonRequestType();
			request.ButtonType = selectedButtonType;
            	.......            
	            BMCreateButtonReq wrapper = new BMCreateButtonReq();
      	      wrapper.BMCreateButtonRequest = request;
            
            	// Invoke the API
      	      PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
	            BMCreateButtonResponseType response = service.BMCreateButton(wrapper);

			// Check API return status
			if(response .Ack.Equals(AckCodeType.FAILURE))
			{
			   .......
			}