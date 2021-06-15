--ALTER TABLE Repairs
--DROP CONSTRAINT FK_product_id

--CREATE TABLE RepairsProducts(
--repair_id UNIQUEIDENTIFIER NOT NULL,
--product_id UNIQUEIDENTIFIER NOT NULL,
--FOREIGN KEY (repair_id) REFERENCES Repairs (id),
--FOREIGN KEY (product_id) REFERENCES Products (id)
--);

--ALTER TABLE Repairs
--DROP CONSTRAINT FK__Repairs__product__20E1DCB5

--DROP INDEX IX_Repairs_product_id ON Repairs

ALTER TABLE Repairs
DROP COLUMN product_id