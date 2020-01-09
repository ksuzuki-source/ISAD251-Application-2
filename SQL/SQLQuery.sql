
CREATE TABLE [dbo].[Customers] (
    [TableId] INT IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([TableId] ASC)
);

CREATE TABLE [dbo].[OrderDetails] (
    [OrderId]   INT      IDENTITY (1, 1) NOT NULL,
    [ProductId] INT      NOT NULL,
    [Quantity]  INT      NOT NULL,
    [Date]      DATETIME NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderId] ASC)
);


CREATE TABLE [dbo].[Products] (
    [ProductId]       INT           IDENTITY (1, 1) NOT NULL,
    [Product_Details] VARCHAR (MAX) NOT NULL,
    [Price]           FLOAT (53)    NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

