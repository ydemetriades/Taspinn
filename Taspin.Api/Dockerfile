FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
COPY . .
RUN dotnet restore "Taspin.sln"
RUN dotnet build "Taspin.sln" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Taspin.sln" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Taspin.Api.dll"]
