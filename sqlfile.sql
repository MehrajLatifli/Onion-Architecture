CREATE DATABASE "OnionArchitecture_Db"

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "Product"
(
    Id  UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    Name TEXT NOT NULL,
    Stock INTEGER NOT NULL,
    Price DOUBLE PRECISION NOT NULL,
    CreateDate timestamp with time zone NOT NULL,
    UpdateDate timestamp with time zone NOT NULL,
    DeleteDate timestamp with time zone NOT NULL
);


CREATE TABLE "Customer"
(
    Id  UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    Name TEXT NOT NULL,
    CreateDate timestamp with time zone NOT NULL,
    UpdateDate timestamp with time zone NOT NULL,
    DeleteDate timestamp with time zone NOT NULL
);



CREATE TABLE "Order"
(
    Id  UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    Description TEXT NOT NULL,
    Address TEXT NOT NULL,
    CreateDate timestamp with time zone NOT NULL,
    UpdateDate timestamp with time zone NOT NULL,
    DeleteDate timestamp with time zone NOT NULL,
    
    CustomerId_forOrder uuid NOT NULL,
    ProductId_forOrder uuid NOT NULL,
    
    CONSTRAINT FK_CustomerId_forOrder FOREIGN KEY (CustomerId_forOrder) REFERENCES "Customer" (Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT FK_ProductId_forOrder FOREIGN KEY (ProductId_forOrder) REFERENCES "Product" (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);


select * from  "Product" p 

select * from  "Customer" c

select * from  "Order" o 

