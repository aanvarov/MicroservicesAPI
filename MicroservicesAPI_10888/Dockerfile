FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicroservicesAPI_10888/MicroservicesAPI_10888.csproj", "MicroservicesAPI_10888/"]
RUN dotnet restore "MicroservicesAPI_10888/MicroservicesAPI_10888.csproj"
COPY . .
WORKDIR "/src/MicroservicesAPI_10888"
RUN dotnet build "MicroservicesAPI_10888.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroservicesAPI_10888.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroservicesAPI_10888.dll"]
