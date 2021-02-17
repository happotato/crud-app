# Simple CRUD App

## Dependencies

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Microsoft SQLServer 2019](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## Setup

```bash
# Clone repository
git clone https://github.com/happotato/crud-app.git

# Change to directory
cd crud-app

# Restore 
dotnet restore 
```
### Environment

Use the [template](appsettings.Template.json) to create the `appsettings.json`.

### Database

```bash
# Install tools
dotnet tool install --global dotnet-ef 

# Update database
dotnet ef database update
```

### Running

```bash
# Build
dotnet build

# Start the application
dotnet run
```

### Running with Docker

```bash
# Build
docker build -t crud-app .

# Start the application
docker run -d -p 5000:80 crud-app
```
