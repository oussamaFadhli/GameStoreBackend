# Game Store API

## Starting SQL Server

```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql -d mcr.microsoft.com/mssql/server:2022-latest

```
## setting the connection string to secret manager

```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStorContext" "Server=(localdb)\\local;Database=GameStore;User Id=sa;Password=$sa_password;TrustServerCertificate=True;Trusted_Connection=True;Trusted_Connection=True"
```