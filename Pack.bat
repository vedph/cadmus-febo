@echo off
echo BUILD Cadmus Febo Packages
del .\Cadmus.Febo.Services\bin\Release\*.snupkg
del .\Cadmus.Febo.Services\bin\Release\*.nupkg

cd .\Cadmus.Febo.Services
dotnet pack -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
