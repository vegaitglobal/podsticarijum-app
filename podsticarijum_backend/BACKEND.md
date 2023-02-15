## How to run locally: 

### Docker
You need email password. Ask around. 
Set that value as environment variable with the name `MailData__Password`.

You need to provide a password for MS SQL server by setting a value for a new variable (of your choosing) named `MSSQL_SA_PASSWORD`.
Beware that the SQL DB uses a Docker volume.  

### Dotnet
You can use user secrets or set OS env variables. 
Names for variables are: 
- `MAIL_DATA_PASSWORD`
- `DB_PASSWORD`


For user secrets see: 
- https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows#enable-secret-storage
- https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows#set-a-secret

