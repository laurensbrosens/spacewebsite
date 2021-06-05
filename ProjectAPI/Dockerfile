ARG build_version
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ProjectAPI/*.csproj ./ProjectAPI/
RUN dotnet restore -p:RestoreUseSkipNonexistentTargets=false -nowarn:msb3202,nu1503

# copy everything else and build app
COPY ProjectAPI/. ./ProjectAPI/
WORKDIR /app/ProjectAPI
RUN dotnet publish -c Release

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
RUN ls -l
WORKDIR /app/bin
RUN ls -l
WORKDIR /app/Release
RUN ls -l
WORKDIR /app/Release/netcoreapp3.1
RUN ls -l
COPY --from=0 /app/bin/Release/netcoreapp3.1/publish /app/
ENTRYPOINT ["dotnet", "ProjectAPI.dll"]
