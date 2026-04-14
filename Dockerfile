# Use the ASP.NET Core runtime as the base image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy the csproj file and restore dependencies
COPY ["TaskTrackerApp/TaskTrackerApp.csproj", "TaskTrackerApp/"]
RUN dotnet restore "TaskTrackerApp/TaskTrackerApp.csproj"

# Copy the remaining project files
COPY . .

# Build the application
WORKDIR "/src/TaskTrackerApp"
RUN dotnet build "TaskTrackerApp.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "TaskTrackerApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskTrackerApp.dll"]
