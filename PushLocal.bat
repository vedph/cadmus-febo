@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Febo.Services\bin\Release\Cadmus.Febo.Services.3.0.7.nupkg -source C:\Projects\_NuGet
pause
