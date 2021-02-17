FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore CrudApp.csproj

COPY . ./
RUN dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY --from=build-env /app/out .

EXPOSE 80
ENTRYPOINT ["dotnet", "CrudApp.dll", "--urls", "http://*:80"]
