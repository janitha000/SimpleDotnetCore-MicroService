FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Items.Basket/Items.Basket/Items.Basket.csproj", "Items.Basket/Items.Basket/"]
RUN dotnet restore "Items.Basket/Items.Basket/Items.Basket.csproj"
COPY . .
WORKDIR "/src/Items.Basket/Items.Basket"
RUN dotnet build "Items.Basket.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Items.Basket.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Items.Basket.dll"]