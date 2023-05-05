USE DapperDb
GO
--------------------------
CREATE PROCEDURE usp_GetAllPruducts
AS
BEGIN
	SELECT *
	FROM Products
END
GO
EXEC usp_GetAllPruducts
GO
---------------------------
CREATE PROCEDURE usp_GetProductById
@Id INT
AS
BEGIN
	SELECT *
	FROM Products
	WHERE Id = @Id
END
GO
------------------------------
CREATE PROCEDURE usp_InsertProduct
@Name NVARCHAR(50),
@Price INT,
@ProductID INT OUTPUT
AS
BEGIN
	INSERT INTO Products(Name, Price)
	VALUES(@Name, @Price)
	SET @ProductID = SCOPE_IDENTITY()
END
GO
----------------------------------
CREATE PROCEDURE usp_DeleteProductById
@Id INT
AS
BEGIN
	DELETE FROM Products
	WHERE Id = @Id
END
GO
---------------------------------------
CREATE PROCEDURE usp_UpdateProduct
@Id INT,
@Name NVARCHAR(50),
@Price INT
AS
BEGIN
	UPDATE Products
	SET Name = @Name,
	Price = @Price
	WHERE Id = @Id
END
GO
---------------------------------------
