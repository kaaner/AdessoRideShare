#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AdessoRideShare.Service/AdessoRideShare.Service.csproj", "AdessoRideShare.Service/"]
RUN dotnet restore "AdessoRideShare.Service/AdessoRideShare.Service.csproj"
COPY . .
WORKDIR "/src/AdessoRideShare.Service"
RUN dotnet build "AdessoRideShare.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdessoRideShare.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdessoRideShare.Service.dll"]