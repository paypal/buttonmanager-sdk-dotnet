This repository contains .NET SDK and samples for Adaptive Accounts API.

Prerequisites:
--------------
*	Visual Studio 2005 or higher

SDK Integration:
----------------
*	Create a new ASP.NET Web Application with appropriate web application and solution name

*	Add 'PayPal_ButtonManager_SDK.csproj' as 'Existing Project' to your solution

*	In case of a higher version of Visual Studio, use the Visual Studio Convertion Wizard to target .NET Framework 2.0

*	Add reference to 'PayPal_ButtonManager_SDK' project

*	Add reference to 'PayPal_Core_SDK.dll' from the 'lib' folder in 'PayPal_ButtonManager_SDK' project

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
	•	apiSignature
	•	applicationId
	•	subject

Tool:
------
*	log4net.dll - included in 'lib' folder in 'PayPal_ButtonManager_SDK' project
	log4net is a tool to help output log statements to a variety of output targets.
	