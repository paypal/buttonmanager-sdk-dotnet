@echo off

:run
echo Generating NDoc 


echo %cd%

set NDOC="Tools\NDoc\NDocConsole.exe"

%NDOC% -documenter=MSDN-CHM PayPal_Invoicing_SDK\bin\Release\PayPal_Invoicing_SDK.DLL

move doc\Documentation.chm "PayPal_Invoicing_SDK\docs\PayPalInvoiceAPI.chm"

del doc\* /q

del doc\ndoc_msdn_temp\* /q

rd doc\ndoc_msdn_temp

rd doc

:end
