FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["global.json", "./"]
COPY ["src/ShoppingList.API/ShoppingList.API.csproj", "src/ShoppingList.API/"]
COPY ["src/ShoppingList.Application/ShoppingList.Application.csproj", "src/ShoppingList.Application/"]
COPY ["src/ShoppingList.Infrastructure/ShoppingList.Infrastructure.csproj", "src/ShoppingList.Infrastructure/"]
COPY ["src/ShoppingList.Domain/ShoppingList.Domain.csproj", "src/ShoppingList.Domain/"]

RUN dotnet restore "src/ShoppingList.API/ShoppingList.API.csproj"

COPY . .

RUN dotnet publish "src/ShoppingList.API/ShoppingList.API.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

RUN apt-get update \
    && apt-get install -y --no-install-recommends curl \
    && rm -rf /var/lib/apt/lists/*

EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ShoppingList.API.dll"]