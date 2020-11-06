FROM mcr.microsoft.com/dotnet/core/sdk AS build-env

RUN mkdir -p /usr/share/man/man1 /usr/share/man/man2

RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jre

RUN dotnet tool install --global dotnet-sonarscanner --version 4.10.0
ENV PATH="${PATH}:/root/.dotnet/tools"
ENV JAVA_TOOL_OPTIONS -Dfile.encoding=UTF8

COPY . ./BowlingCounterApp
WORKDIR /BowlingCounterApp

RUN dotnet restore

RUN dotnet test \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=opencover

RUN dotnet sonarscanner begin /k:"henrique-BowlingApp" \
    /d:sonar.host.url="http://192.168.0.106:9000" \
    /d:sonar.verbose=true \
    /v:1.0.0 \
    /d:sonar.login="b0c7399c221b3b47da89a290a8f936a2a5089989" \
    /d:sonar.cs.opencover.reportsPaths="./BowlingCounterApp.Tests/coverage.opencover.xml"

RUN dotnet build
RUN dotnet sonarscanner end /d:sonar.login="b0c7399c221b3b47da89a290a8f936a2a5089989"
