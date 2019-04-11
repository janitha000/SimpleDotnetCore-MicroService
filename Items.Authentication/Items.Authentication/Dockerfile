FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Items.Authentication/Items.Authentication.csproj", "Items.Authentication/"]
RUN dotnet restore "Items.Authentication/Items.Authentication.csproj"
COPY . .
WORKDIR "/src/Items.Authentication"
RUN dotnet build "Items.Authentication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Items.Authentication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Items.Authentication.dll"]