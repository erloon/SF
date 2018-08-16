FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 50574
EXPOSE 44341

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY SF.API/SF.API.csproj SF.API/
RUN dotnet restore SF.API/SF.API.csproj
COPY . .
WORKDIR /src/SF.API
RUN dotnet build SF.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SF.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SF.API.dll"]
