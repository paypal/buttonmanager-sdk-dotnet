call "C:\Program Files (x86)\Microsoft Visual Studio 8\Common7\IDE\devenv.com" PayPalButtonManagerSDK\PayPalButtonManagerSDK.sln /build Release %1

copy /Y PayPalButtonManagerSDK\bin\Release\PayPalButtonManagerSDK.dll Samples\ButtonManagerAPISample\lib\. 
