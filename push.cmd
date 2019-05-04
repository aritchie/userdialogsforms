@echo off
nuget push .\Acr.UserDialogs.Forms\bin\Release\*.nupkg -Source https://www.nuget.org/api/v2/package
del .\Acr.UserDialogs.Forms\bin\Release\*.nupkg
pause