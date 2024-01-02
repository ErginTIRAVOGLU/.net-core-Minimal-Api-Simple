# Game Store API

## Starting SQL Server

```powershell
$sa_password = "[SA PASSWORD]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string to secret manager

```powershell
$sa_password = "[SA PASSWORD]"
dotnet user-secrests set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
```

## No Need

"ConnectionStrings": {
  "GameStoreContext":"Server=localhost; Database=GameStore; User Id=sa; Password=PASSWORD; TrustServerCertificate=True"
}
