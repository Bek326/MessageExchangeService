# Use the official .NET SDK 8.0 image for build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["MessageExchangeService/MessageExchangeService.csproj", "MessageExchangeService/"]
RUN dotnet restore "MessageExchangeService/MessageExchangeService.csproj"

# Copy the remaining files and build the project
COPY . .
WORKDIR "/src/MessageExchangeService"
RUN dotnet build "MessageExchangeService.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "MessageExchangeService.csproj" -c Release -o /app/publish

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "MessageExchangeService.dll"]


