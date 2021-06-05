FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ProjectAPI/*.csproj ./ProjectAPI/
RUN dotnet restore

# copy everything else and build app
COPY ProjectAPI/. ./ProjectAPI/
WORKDIR /app/ProjectAPI
RUN dotnet publish -c Debug -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/ProjectAPI/out ./
ENTRYPOINT ["dotnet", "ProjectAPI.dll"]