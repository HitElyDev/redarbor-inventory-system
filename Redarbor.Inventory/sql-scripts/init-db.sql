
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'InventoryDb')
BEGIN
  CREATE DATABASE InventoryDb;
END
GO

USE InventoryDb;
GO

-- Aquí pones el resto de tu código (CREATE TABLE para Products, Categories, etc.)
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
    CREATE TABLE Categories (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL,
        Description NVARCHAR(255)
    );
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
BEGIN
    CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CategoryId INT NOT NULL,
    Name NVARCHAR(150) NOT NULL,
    Sku NVARCHAR(50) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL DEFAULT 0
);
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryMovements]') AND type in (N'U'))
BEGIN
    CREATE TABLE InventoryMovements (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Type NVARCHAR(20) NOT NULL, 
    MovementDate DATETIME DEFAULT GETDATE()
);
END
GO