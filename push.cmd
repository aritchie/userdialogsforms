@echo off
nuget push .\src\Acr.UserDialogs.Forms\bin\Release\*.nupkg -Source https://www.nuget.org/api/v2/package
del .\src\Acr.UserDialogs.Forms\bin\Release\*.nupkg
pause