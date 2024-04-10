Clothes Store Api
A .Net 8 Web Api Project that mimics the basic functionalities of a Clothes EShop

Technologies used
C# (NET 8 Framework)
SQL Server (2022 Edition)
Dapper (For ORM Functionalities)

Installaion / Basic Use

After you clone the repo, in appsettings.json of Clothes.Store.Api project you complete in the ConnectionStrings section the connection string of your choice
Example:  "ConnectionStrings": {
  "DbConnection": "Server=localhost;Database=ClothesStore;User Id=whatever;Password=whatever;"
}.

After that you utilize the sql scripts in the Sql.Scripts folder of Clothes.Store.Db project for database and stored procedures creation.

Once this is setup, you press the debug mode of Visual Studio 2022 and you are all set to go!
