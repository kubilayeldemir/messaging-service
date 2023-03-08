FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MessagingService.Api/MessagingService.Api.csproj", "MessagingService.Api/"]
RUN dotnet restore "MessagingService.Api/MessagingService.Api.csproj"
COPY . .
WORKDIR "/src/MessagingService.Api"
RUN dotnet build "MessagingService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MessagingService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessagingService.Api.dll"]
