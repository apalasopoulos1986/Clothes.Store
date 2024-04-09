CREATE PROCEDURE InsertProductResponseFromWebService
    @Id INT,
    @Title NVARCHAR(255),
    @Price DECIMAL(10, 2),
    @Description NVARCHAR(MAX),
    @Category NVARCHAR(100),
    @Image NVARCHAR(MAX),
    @Rating NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO Products (Id, Title, Price, Description, Category, Image, Rating)
    VALUES (@Id, @Title, @Price, @Description, @Category, @Image, @Rating)
END
GO