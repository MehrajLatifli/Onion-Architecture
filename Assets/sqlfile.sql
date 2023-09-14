CREATE DATABASE [OnionArchitecture_Db]

Use [OnionArchitecture_Db]

CREATE TABLE [Product]
(
    Id   INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    Name NVARCHAR(max) NOT NULL,
    Stock INTEGER NOT NULL,
    Price DOUBLE PRECISION NOT NULL,
    CreateDate datetime2 NOT NULL default NULL, 
    UpdateDate datetime2 NOT NULL default NULL, 
    DeleteDate datetime2 NOT NULL default NULL, 
);


CREATE TABLE [Customer]
(
    Id   INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    Name NVARCHAR(max) NOT NULL,
    CreateDate datetime2 NOT NULL default NULL, 
    UpdateDate datetime2 NOT NULL default NULL, 
    DeleteDate datetime2 NOT NULL default NULL, 
);



CREATE TABLE [Order]
(
    Id   INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    Description NVARCHAR(max) NOT NULL,
    Address NVARCHAR(max) NOT NULL,
    CreateDate datetime2 NOT NULL default NULL, 
    UpdateDate datetime2 NOT NULL default NULL, 
    DeleteDate datetime2 NOT NULL default NULL,  
    
    CustomerId_forOrder  int NOT NULL,
    ProductId_forOrder  int NOT NULL,
    
    CONSTRAINT FK_CustomerId_forOrder FOREIGN KEY (CustomerId_forOrder) REFERENCES "Customer" (Id) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_ProductId_forOrder FOREIGN KEY (ProductId_forOrder) REFERENCES "Product" (Id) ON DELETE CASCADE ON UPDATE CASCADE
);


select * from  [Product] p;

select * from  [Customer] c;

select * from  [Order] o ;

