FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Vehicle.Api/Vehicle.Api.csproj", "Vehicle.Api/"]
RUN dotnet restore "Vehicle.Api/Vehicle.Api.csproj"
COPY . .
WORKDIR "/src/Vehicle.Api"
RUN dotnet build "Vehicle.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Vehicle.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Vehicle.Api.dll"]