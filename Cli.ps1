# build
dotnet build -c Debug
# publish library
Remove-Item -Path .\Cadmus.Febo.Services\bin\Debug\net8.0\publish -Recurse -Force
dotnet publish .\Cadmus.Febo.Services\Cadmus.Febo.Services.csproj -c Debug
# rename publish to Cadmus.Febo.Services and zip
Rename-Item -Path .\Cadmus.Febo.Services\bin\Debug\net8.0\publish -NewName Cadmus.Febo.Services
compress-archive -path .\Cadmus.Febo.Services\bin\Debug\net8.0\Cadmus.Febo.Services\ -DestinationPath .\Cadmus.Febo.Services\bin\Debug\net8.0\Cadmus.Febo.Services.zip -Force
# rename back
Rename-Item -Path .\Cadmus.Febo.Services\bin\Debug\net8.0\Cadmus.Febo.Services -NewName publish
