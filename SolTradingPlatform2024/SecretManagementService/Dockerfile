#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SecretManagementService/SecretManagementService.csproj", "SecretManagementService/"]
RUN dotnet restore "SecretManagementService/SecretManagementService.csproj"
COPY . .
WORKDIR "/src/SecretManagementService"
RUN dotnet build "SecretManagementService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecretManagementService.csproj" -c Release -o /app/publish

# Use the runtime image as a base image for the final build image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecretManagementService.dll"]
