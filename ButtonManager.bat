call "C:\Program Files (x86)\Microsoft Visual Studio 8\Common7\IDE\devenv.com" PayPal_ButtonManager_SDK.sln /build Release %1

copy /Y PayPal_ButtonManager_SDK\bin\Release\PayPal_ButtonManager_SDK.dll Samples\ButtonManagerAPISample\lib\. 
