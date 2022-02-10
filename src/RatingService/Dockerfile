FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY RatingService.csproj .
RUN dotnet restore --runtime "linux-x64"
COPY . .
RUN dotnet publish --output /app/build -c Release --os linux --no-restore --no-self-contained

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=build-env /app/build .
ENTRYPOINT [ "dotnet", "RatingService.dll" ]