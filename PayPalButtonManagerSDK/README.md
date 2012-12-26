The PayPal Button Manager SDK C#.NET Class Library project contains the PayPal Button Manager Stubs.


Prerequisites
-------------
*	Visual Studio 2005 or higher
*	NuGet.exe 2.2
*	.NET Framework 4.0


The PayPal Button Manager SDK
--------------------------------
*	The PayPal Button Manager SDK helps you to dynamically create, manage, and edit large numbers of PayPal Payments Standard buttons.

*	The PayPal Button Manager SDK provides the following methods:
	BMButtonSearch API Operation (NVP): Use the BMButtonSearch API operation to obtain a list of your hosted Website Payments Standard buttons.
	BMButtonSearch API Operation (SOAP): Use the BMButtonSearch API operation to obtain a list of your hosted Website Payments Standard buttons.
	BMCreateButton API Operation (SOAP): Use the BMCreateButton API operation to create a Website Payments Standard button.
	BMGetButtonDetails API Operation (NVP): Use the BMGetButtonDetails API operation to obtain information about a hosted Website Payments Standard button.
	BMGetButtonDetails API Operation (SOAP): Use the BMGetButtonDetails API operation to obtain information about a hosted Website Payments Standard button.
	BMGetInventory API Operation (NVP): Use the BMGetInventory API operation to determine the inventory levels and other inventory-related information for a button and menu items associated with the button.
	BMGetInventory API Operation (SOAP): Use the BMGetInventory API operation to determine the inventory levels and other inventory-related information for a button and menu items associated with the button.
	BMManageButtonStatus API Operation (NVP): Use the BMManageButtonStatus API operation to change the status of a hosted button. Currently, you can only delete a button.
	BMSetInventory API Operation (NVP): Use the BMSetInventory API operation to set the inventory level and inventory management features for the specified button.
	BMSetInventory API Operation (SOAP): Use the BMSetInventory API operation to set the inventory level and inventory management features for the specified button.
	BMUpdateButton API Operation (NVP): Use the BMUpdateButton API operation to modify a Website Payments Standard button that is hosted on PayPal.
	BMUpdateButton API Operation (SOAP): Use the BMUpdateButton API operation to modify a Website Payments Standard button that is hosted on PayPal.


NuGet – Installing NuGet in Visual Studio 2010 and 2012
-------------------------------------------------------

Go to Visual Studio 2010 Menu --> Tools
Select Extension Manager…
Enter NuGet in the search box and click Online Gallery
Let it Retrieve information…
Select the retrieved NuGet Package Manager, click Download
Let it Download…
Click Install on the Visual Studio Extension Installer NuGet Package Manager
Let it Install…
Click Close and Restart Now

Go to Visual Studio 2010 Menu --> Tools, select Options…
Verify the following on the Options popup
Click Package Manager --> Package Sources
Available package sources:
Check box (checked) NuGet official package source
https://nuget.org/api/v2/
Name: NuGet official package source
Source: https://nuget.org/api/v2/
And click OK
 
Go to Menu --> Tools --> Library Package Manage --> Package Manager Console
Select NuGet official package source from the Package source dropdown box in the Package Manager Console
Go to Solution Explorer and note the existing references
Enter at PM> Install-Package PayPal_Core_SDK
On enter key-press, the output window should display:

Attempting to resolve dependency 'log4net (= 1.2.10)'.
Successfully installed 'log4net 1.2.10'.
You are downloading PayPal_Core_SDK from PayPal, the license agreement to which is available at https://github.com/paypal/sdk-core-dotnet/blob/master/LICENSE.txt. Check the package for additional dependencies, which may come with their own license agreement(s). Your use of the package and dependencies constitutes your acceptance of their license agreements. If you do not accept the license agreement(s), then delete the relevant components from your device.
Successfully installed 'PayPal_Core_SDK 1.0.0'.
Successfully added 'log4net 1.2.10' to PayPal_Core_SDK.
Successfully added 'PayPal_Core_SDK 1.0.0' to PayPal_Core_SDK.

After successful installation, note that the new references get added automatically

Also, go to Menu --> Tools --> Library Package Manager, select Manage NuGet Packages for Solution…
On Manage NuGet Packages, search for 'PayPal_Core_SDK' to get the details
	

NuGet - Integrating NuGet with Visual Studio 2005 and 2008
----------------------------------------------------------

Prerequisites:
•	.NET Framework 4.0
•	NuGet.exe
	
Check if .NET Framework 4.0 is installed in the computer from Control Panel --> Get programs

Or run the following command from Windows command prompt:
>dir  /b  %windir%\Microsoft.NET\Framework\v*

Running the aforesaid command should list the .NET Framework versions installed as follows:
v1.0.3705
v1.1.4322
v2.0.50727
v3.0
v3.5
v4.0.30319

Note: Most Windows machines would have .NET Framework 4.0 installed as part of Windows (recommended) update.

If V4.X is not installed, then download and install
•	.NET Framework 4 (Standalone Installer) – (free to download):
http://www.microsoft.com/en-in/download/details.aspx?id=17718

Or

•	.NET Framework 4 (Web Installer) – (free to download):
http://www.microsoft.com/en-in/download/details.aspx?id=17851

Download NuGet.exe Command Line (free to download): http://nuget.codeplex.com/releases/view/58939

Save NuGet.exe to folder viz., 'C:\NuGet' and add its path to the Environment Variables Path:

Visual Studio 2005 or 2008
Go to Visual Studio Menu --> Tools
Select External Tools…
External Tools
External Tools having 5* default tools in the Menu contents, Click Add
*Note: The number of default tools may differ depending on the particular Visual Studio installation
 
Enter the following:
Title: NuGet Install
Command (Having in Environment Variables Path): NuGet.exe
Arguments: install your.package.name -excludeversion -outputDirectory .\Packages
Initial directory: $(SolutionDir)
Use Output window: Check
Prompt for arguments: Check
Click Apply
Click OK

On Clicking Apply and OK, NuGet Install will be added (as External Command 6*) to Menu --> Tools
*Note: The External Command number may differ depending on the particular Visual Studio installation

Menu --> Tools, clicking NuGet Install will pop up for NuGet Install Arguments and Command Line
Also, NuGet Toolbar can be added, right-click on Visual Studio Menu and select Customize…
Customize by clicking New…
Enter Toolbar name: NuGet and click OK
Check NuGet Checkbox in the Toolbars tab for NuGet Toolbar to pop up
Click Commands tab and select Tools and External Command 6 (Having added NuGet Install as External Command 6*) 
*Note: The External Command number may differ depending on the particular Visual Studio installation
Drag and drop External Command 6 to NuGet Toolbar
Right-click NuGet Toolbar
Enter Name: Install Package
Right-click Change Button Image and select an image
Close Customize
Drag and drop NuGet Toolbar to the Menu
Click the NuGet Toolbar Install Package
Clicking on the NuGet Toolbar Install Package will pop up for NuGet Install Arguments and Command Line
Example NuGet Install:
Enter Arguments: 
install PayPal_Core_SDK -excludeversion -outputDirectory .\Packages

On clicking OK, the output window should display:

Attempting to resolve dependency 'PayPal_Core_SDK'.
Attempting to resolve dependency 'log4net (ò 1.2.10)'.
Successfully installed 'log4net 1.2.10'.
Successfully installed 'PayPal_Core_SDK 1.0.0'.

Menu View --> Output (Ctrl+Alt+O)

The 'PayPal_Core_SDK' Package including the dependencies will be downloaded to the 'Packages' folder root directory of the Solution (.sln) file.

Select 'Packages' folder and click 'Refresh' in the Solution Explorer
Note: If 'Packages' folder was not included in the Solution Explorer, click 'Show All Files' before clicking 'Refresh'
Add the references to the dependent files downloaded to 'Packages' folder:

Note: By default, the root directory of Nuget Installation is the same as that of the Solution (.sln) file.
In case of a direct installation using Visual Studio without loading any solution: 
The typical location for Visual Studio 2005:    
 'C:\Program Files (x86)\Microsoft Visual Studio 8\Common7\IDE\'
The typical Installation location for Visual Studio 2008:
'C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\'