#!/bin/bash
cd neutralino-blazor
dotnet publish -c Release
cp -R bin/Release/net10.0/publish/wwwroot/ ../../resources
cp ../resources/index.html ../../resources
