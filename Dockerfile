# Stage 1: Build the .NET application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /app
COPY . .

RUN dotnet restore

WORKDIR /app/MinimalBookApi/
RUN dotnet publish -c Release -o ../out --no-restore

# Stage 2: Set up Nginx and copy the published output

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose the port that Nginx will listen on
EXPOSE 5256

# Start Nginx
ENTRYPOINT ["dotnet", "MinimalBookApi.dll"]
