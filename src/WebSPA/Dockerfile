FROM mcr.microsoft.com/dotnet/sdk:6.0 as server-build
WORKDIR /server-app
COPY "WebServer/WebServer.csproj" "/server-app/WebServer.csproj"
RUN dotnet restore --runtime=linux-x64 "WebServer.csproj"
COPY WebServer/ /server-app/
RUN dotnet publish -o /server-app/build/ -c=Release --os=linux --no-restore --no-self-contained

FROM node:17.5 as spa-build
WORKDIR /web-spa
COPY client-app/package.json /web-spa/
COPY client-app/package-lock.json /web-spa/
RUN npm install -g npm@8
RUN npm install
COPY client-app/ /web-spa
RUN npm run build

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as final
WORKDIR /app
COPY --from=server-build /server-app/build/ /app/
COPY --from=spa-build /web-spa/build/ /app/ReactApp/
ENTRYPOINT ["dotnet", "WebServer.dll"]