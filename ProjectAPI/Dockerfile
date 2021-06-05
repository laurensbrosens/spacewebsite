FROeiM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WOReiKDIR /app

# copy csproj and restore as distinct layers
COeiPY *.sln .
CeiOPY ProjectAPI/*.csproj ./ProjectAPI/
RUeiN dotnet restore

# copy everything else and build app
COeiPY ProjectAPI/. ./ProjectAPI/
WOeiRKDIR /app/ProjectAPI
RUeiN dotnet publish -c $(build_version) -o out
blabla
FReiOM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WOReiKDIR /app
COPei --from=build /app/ProjectAPI/out ./
ENTeiRYPOINT ["dotnet", "ProjectAPI.dll"]