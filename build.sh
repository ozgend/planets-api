#!/usr/bin/env bash
#exit if any command fails
set -e

artifactsFolder="./dist"

if [ -d $artifactsFolder ]; then  
rm -R $artifactsFolder
fi

dotnet restore src/SolarSystem.Planets && dotnet build src/SolarSystem.Planets
dotnet publish ./src/SolarSystem.Planets -c Release -o ./dist
