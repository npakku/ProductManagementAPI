# Use official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy project files
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build the app
COPY . .
RUN dotnet publish -c Release -o out

# Use a lightweight runtime image for production
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "YourAppName.dll"]
