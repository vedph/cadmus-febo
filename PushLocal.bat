@echo off
echo PRESS ANY KEY TO INSTALL Cadmus Libraries TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Febo.Services\bin\Debug\Cadmus.Febo.Services.1.0.2.nupkg -source C:\Projects\_NuGet
pause
