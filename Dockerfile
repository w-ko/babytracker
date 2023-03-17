FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src", "/opt/app"]
RUN dotnet restore "/opt/app/Wko.BabyTracker.Web/Wko.BabyTracker.Web.csproj"
COPY . .
WORKDIR "/src/app"
RUN dotnet build "/opt/app/Wko.BabyTracker.Web/Wko.BabyTracker.Web.csproj" -c Release -o /opt/app/build

FROM build AS publish
RUN dotnet publish "/opt/app/Wko.BabyTracker.Web/Wko.BabyTracker.Web.csproj" -c Release -o /opt/app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /opt/app/publish .
ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "Wko.BabyTracker.Web.dll"]
