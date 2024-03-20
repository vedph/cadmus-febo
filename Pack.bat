@echo off
echo BUILD Cadmus Febo Packages
del .\Cadmus.Febo.Services\bin\Debug\*.snupkg
del .\Cadmus.Febo.Services\bin\Debug\*.nupkg

cd .\Cadmus.Febo.Services
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
