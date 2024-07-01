FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerReviewService/CustomerReviewService.csproj", "CustomerReviewService/"]
RUN dotnet restore "./CustomerReviewService/CustomerReviewService.csproj"
COPY . .
WORKDIR "/src/CustomerReviewService"
RUN dotnet build "./CustomerReviewService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CustomerReviewService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
