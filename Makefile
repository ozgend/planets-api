.PHONY: build_dotnet build clean

build:
    build_angular

build_dotnet:
    cd src\SolarSystem.Planets && dotnet build