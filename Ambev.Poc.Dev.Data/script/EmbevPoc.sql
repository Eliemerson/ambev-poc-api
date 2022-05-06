Create DATABASE AmbevPoc
Use AmbevPoc


CREATE TABLE Customer (
	[Id] [int] IDENTITY(1,1) Primary Key NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Name] varchar(50) NOT NULL,
	[LastName] varchar(50) NOT NULL,
	[Email] varchar(255) NOT NULL,
	[IsActive] bit NOT NULL
);

CREATE TABLE Product (
	[Id] [int] IDENTITY(1,1) Primary Key NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[Name] varchar(50) NOT NULL,
	[Sku] varchar(50) NOT NULL,
	[Price] decimal(18,2) NOT NULL,
	[Category] varchar(50) NOT NULL,
	[IsActive] bit NOT NULL
);

CREATE TABLE OrderProduct (
	[Id] [int] IDENTITY(1,1) Primary Key NOT NULL,
	[Guid] uniqueidentifier NOT NULL,
	[ProductId] Int NOT NULL,
	[CustomerId] Int NOT NULL,
	[TotalOrder] decimal(18,2) NOT NULL,
	[Amount] Int NOT NULL,
    CONSTRAINT [FK_OrderProduc_ProductId] FOREIGN KEY([ProductId]) REFERENCES Product(Id),
    CONSTRAINT [FK_OrderProduc_CustomerId] FOREIGN KEY([CustomerId]) REFERENCES Customer(Id)
);


Select TOP 100 * from Customer;
Select TOP 100 * from Product;
Select TOP 100 * from OrderProduct;
