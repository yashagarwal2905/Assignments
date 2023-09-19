--Creating Database--
CREATE DATABASE ShoppingCartDb

--Creating Tables--
CREATE TABLE Users
(
	UserID INT PRIMARY KEY,
	Username VARCHAR(50),
	Password VARCHAR(50),
	ContactNumber VARCHAR(10),
	City VARCHAR(50)
);

CREATE TABLE Products
(
	ProductID INT PRIMARY KEY,
	ProductName VARCHAR(50) NOT NULL,
	QuantityInStock INT NOT NULL,
	UnitPrice INT NOT NULL,
	CONSTRAINT  CHK_QUANT CHECK (QuantityInStock >0),
	CONSTRAINT  CHK_UNIT_PRICE CHECK (UnitPrice >0),
	Category VARCHAR(50) NOT NULL,
);

CREATE TABLE Cart
(
	CartID INT PRIMARY KEY NOT NULL,
	ProductID INT FOREIGN KEY(ProductID)
	REFERENCES Products(ProductID),
	Quantity INT NOT NULL
	CONSTRAINT  CHK_QUANTITY CHECK (Quantity >0),
);


CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY,
	CardID INT NOT NULL,
	OrderDate DATE,
	TotalAmount INT,
	UserID INT FOREIGN KEY(UserID)
	REFERENCES Users(UserID),
);

--Table Insertions-- 

INSERT INTO Users VALUES (10,'YASH123','YASH@123','1233567890','DELHI');
INSERT INTO Users VALUES (20,'SARTHAK123','SARTHAK@123','0987654321','CHANDIGARH');
INSERT INTO Users VALUES (30, 'MOHINI123','MOHINI@123','6767676767','BHOPAL');
INSERT INTO Users VALUES (40,'KARAN123','KARAN@123','9898989898','ASSAM');
INSERT INTO Users VALUES (50,'SWETHA123','SWETHA@123','9898767654','HYDERABAD');

INSERT INTO Products VALUES (1,'TABLE',20,10000,'FURNITURE');
INSERT INTO Products VALUES (2,'CHAIR',30,12000,'FURNITURE');
INSERT INTO Products VALUES (3, 'LAPTOP',45,100000,'ELECTRONICS');
INSERT INTO Products VALUES (4,'PEN',100,30,'STATIONARY');
INSERT INTO Products VALUES (5,'NOTEBOOK',70,150,'STATIONARY');
INSERT INTO Products VALUES (6,'CHARGER',50,1500,'ELECTRONICS');

INSERT INTO Cart VALUES (101,2,5);
INSERT INTO Cart VALUES (102,5,12);
INSERT INTO Cart VALUES (103,4,20);
INSERT INTO Cart VALUES (104,3,10);
INSERT INTO Cart VALUES (105,1,8);

INSERT INTO Orders VALUES (12345,111,'2023-08-23',150000,20);
INSERT INTO Orders VALUES (12346,112,'2023-06-29',12000,30);
INSERT INTO Orders VALUES (12347,113,'2023-10-06',70450,20);
INSERT INTO Orders VALUES (12348,114,'2023-04-12',40500,40);
INSERT INTO Orders VALUES (12349,115,'2023-05-29',23700,50);

--Queries--
--Product Table--
SELECT * FROM Products
SELECT * FROM Products WHERE Category='FURNITURE'
SELECT * FROM Products WHERE (UnitPrice>1000 AND UnitPrice<10000)
SELECT * FROM Products WHERE ProductID=3

--Cart Table--
SELECT * FROM Cart WHERE CartID=102
SELECT * FROM Cart WHERE ProductID=4

--Users Table--
SELECT * FROM Users
SELECT * FROM Users WHERE ContactNumber='0987654321'

--Orders Table--
SELECT * FROM Orders WHERE OrderID=12346
SELECT * FROM Orders WHERE UserID=20
SELECT * FROM Orders WHERE OrderDate='2023-05-29'