FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
COPY *.sln .
COPY ProjectAPI/*.csproj ./ProjectAPI/
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY ProjectAPI/. ./ProjectAPI/
FROM build AS publish
COPY ProjectAPI/. ./ProjectAPI/
WORKDIR /app/ProjectAPI
RUN dotnet publish -c Release

FROM base AS final
WORKDIR /app
COPY --from=0 /app/ProjectAPI/ProjectAPI/bin/Release/netcoreapp3.1/publish ./
ENTRYPOINT ["dotnet", "ProjectAPI.dll"]
