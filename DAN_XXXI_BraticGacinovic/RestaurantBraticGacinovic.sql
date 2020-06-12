IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'RestaurantBraticGacinovic')
CREATE database RestaurantBraticGacinovic;
GO


IF OBJECT_ID('tblRecords', 'U') IS NOT NULL DROP TABLE tblRecords;
IF OBJECT_ID('tblOrders', 'U') IS NOT NULL DROP TABLE tblOrders;

use RestaurantBraticGacinovic
CREATE table tblRecords (
RecordID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
OrderTime datetime, 
Code int);

create table tblOrders(
OrderID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Article nvarchar(30),
Quantity int,
RecordID int foreign key references tblRecords(RecordID));