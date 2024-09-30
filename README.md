Clothes Store Api
A .Net 8 Web Api Project that mimics the basic functionalities of a Clothes EShop

Within the code, a data structure is to be created using a pattern of your choice.
After processing the data, it should be retrievable using a REST interface. 
In addition, products from the Rest API mentioned below are to be queried.
Furthermore, the data should be called from the API using a stored procedure. 
 The entire data should be stored in a normalized database.



REST-API:

    1.  https://fakestoreapi.com/products/

The API need to:

    1.  
Retrieve all users (in an optimised way)

    2.  
Creating a user

    3.  
Fetch a user by id

    4.  
Delete a user by id

    5.  
One user should have the possibility to buy one product

    6.  
Get all users who purchased products with productId

    7.  
Get all purchased products from one user


Technologies used
C# (NET 8 Framework)
SQL Server (2022 Edition)
Dapper (For ORM Functionalities)

Installation / Basic Use

After you clone the repo, in appsettings.json of Clothes.Store.Api project you complete in the ConnectionStrings section the connection string of your choice
Example:  "ConnectionStrings": {
  "DbConnection": "Server=localhost;Database=ClothesStore;User Id=whatever;Password=whatever;"
}.

After that you utilize the sql scripts in the Sql.Scripts folder of Clothes.Store.Db project for database and stored procedures creation.

Once this is setup, you press the debug mode of Visual Studio 2022 and you are all set to go!
