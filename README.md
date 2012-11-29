This repository contains .NET SDK and samples for PayPal Button Manager API.

Prerequisites:
--------------
*	Visual Studio 2005 or higher

SDK Integration:
----------------
*	Create a new ASP.NET Web Application with appropriate web application and solution name

*	Execute 'ButtonManager.bat' batch commands to ensure that the Button Manager stubs are up-to-date 
	[Note: Also ensure that the path to 'devenv.com' in 'ButtonManager.bat' file is correct as per Visual Studio installation]
	
*	Add reference to 'PayPal_ButtonManager_SDK.dll'

*	Add reference to 'PayPal_Core_SDK.dll'

*	Namespaces to be used
	•	PayPal
	•	PayPal.PayPalAPIInterfaceService
	•	PayPal.PayPalAPIInterfaceService.Model
	•	PayPal.Util
	•	PayPal.Exception
 
Web.config:
-----------
Please refer to the sample web.config file in 'ButtonManagerAPISample' sample application to configure the following
 
*	Configuration Sections
	•	paypal
	•	log4net

*	PayPal Settings
	•	paypalUrl
	•	endpoint
	•	connectionTimeout
	•	requestRetries
	•	IPAddress
	•	sandboxEmailAddress

*	PayPal (Multiple) Accounts API credentials
	•	apiUsername
	•	apiPassword
	•	applicationId
	•	apiSignature
	•	apiCertificate
	•	privateKeyPassword

Tool:
------
*	log4net.dll - included in 'lib' folder in 'PayPal_ButtonManager_SDK' project
	log4net is a tool to help output log statements to a variety of output targets.