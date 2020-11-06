FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update && apt-get install -y procps
RUN curl -sSL https://aka.ms/getvsdbgsh | sh /dev/stdin -v latest -l /vsdbg

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["BowlingCounterApp.Api/BowlingCounterApp.Api.csproj", "BowlingCounterApp.Api/"]
RUN dotnet restore "BowlingCounterApp.Api/BowlingCounterApp.Api.csproj"
COPY . .

WORKDIR "/src/BowlingCounterApp.Api"
ARG ReleaseType=Release
RUN dotnet build "BowlingCounterApp.Api.csproj" -c ${ReleaseType} -o /app/build

FROM build AS publish
ARG ReleaseType=Release
RUN dotnet publish "BowlingCounterApp.Api.csproj" -c ${ReleaseType} -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BowlingCounterApp.Api.dll"]
