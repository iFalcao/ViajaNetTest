FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ViajaNet/ViajaNet.csproj", "ViajaNet/"]
RUN dotnet restore "ViajaNet/ViajaNet.csproj"
COPY . .
WORKDIR "/src/ViajaNet"
RUN dotnet build "ViajaNet.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ViajaNet.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ViajaNet.dll"]