FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_6.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup

WORKDIR /app
EXPOSE 51826
EXPOSE 44319

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY UI/SF.UI.Web/SF.UI.Web.csproj UI/SF.UI.Web/
RUN dotnet restore UI/SF.UI.Web/SF.UI.Web.csproj
COPY . .
WORKDIR /src/UI/SF.UI.Web
RUN dotnet build SF.UI.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SF.UI.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SF.UI.Web.dll"]
