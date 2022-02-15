FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ShoppingWebAPI/ShoppingWebAPI.csproj", "ShoppingWebAPI/"]
RUN dotnet restore "ShoppingWebAPI/ShoppingWebAPI.csproj"
COPY . .
WORKDIR "/src/ShoppingWebAPI"
RUN dotnet build "ShoppingWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingWebAPI.dll"]