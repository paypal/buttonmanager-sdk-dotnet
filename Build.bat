@echo off

ECHO PayPal Button Manager SDK for .NET
ECHO ======================================

SET VSTOOLS=%VS140COMNTOOLS%
IF "%VSTOOLS%"=="" GOTO :VS_NOT_FOUND

SET IDE_DIR=%VSTOOLS%\..\IDE
SET DEVENV="%IDE_DIR%\devenv.com"
%DEVENV% PayPalButtonManagerSDK\PayPalButtonManagerSDK.sln /clean Release
%DEVENV% PayPalButtonManagerSDK\PayPalButtonManagerSDK.sln /build Release
GOTO :END

:VS_NOT_FOUND
ECHO Visual Studio 2015 was not found.

:END