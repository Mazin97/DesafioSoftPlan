#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FeeApi/FeeApi.csproj", "FeeApi/"]
RUN dotnet restore "FeeApi/FeeApi.csproj"
COPY . .
WORKDIR "/src/FeeApi"
RUN dotnet build "FeeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeeApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeeApi.dll"]
