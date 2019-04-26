FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Items.Api/Items.Api.csproj", "Items.Api/"]
RUN dotnet restore "Items.Api/Items.Api.csproj"
COPY . .
WORKDIR "/src/Items.Api"
RUN dotnet build "Items.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Items.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Items.Api.dll"]