USE [ClothesStore]
GO
/****** Object:  StoredProcedure [dbo].[UpdateProductResponseFromWebService]    Script Date: 10/4/2024 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateProductResponseFromWebService]
    @Id INT,
    @Title NVARCHAR(255),
    @Price DECIMAL(10, 2),
    @Description NVARCHAR(MAX),
    @Category NVARCHAR(100),
    @Image NVARCHAR(MAX),
    @Rating NVARCHAR(MAX)
AS
BEGIN
    UPDATE Products
    SET Title = @Title, 
        Price = @Price, 
        Description = @Description, 
        Category = @Category, 
        Image = @Image, 
        Rating = @Rating
    WHERE Id = @Id
END