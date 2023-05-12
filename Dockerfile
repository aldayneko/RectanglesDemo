FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY src .
WORKDIR /src/RectanglesDemo.Api
RUN dotnet restore "RectanglesDemo.Api.csproj"
RUN dotnet build "RectanglesDemo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RectanglesDemo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RectanglesDemo.Api.dll"]