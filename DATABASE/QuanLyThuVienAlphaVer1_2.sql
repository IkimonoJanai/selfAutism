--C:\Users\Beosama\Desktop\Study\colledge\Kiểm thử phần mềm\DemoDATABASE

IF DB_ID('DemoQuanLyThuVienAlphaVer1_3') IS NULL 
	CREATE DATABASE DemoQuanLyThuVienAlphaVer1_3
GO


USE DemoQuanLyThuVienAlphaVer1_3
GO

-- Book 1
-- Book Storage 2
-- BookCategory 1
-- Account 1
-- Student 1
-- Rent / phieu muon -> bill 1
-- RentInfo / thong tin phieu -> billinfo 1


--CHANGE LOG


--PLAN
--fix type int => type nvarchar 
--02/11/2018
-- fix Book add more colunm quantity , picture
-- student add phoneNumber remove status?

--FIXED
-- 1_3
-- add book storage


CREATE TABLE Student
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Học sinh chưa có tên',
	mssv NVARCHAR(100) NOT NULL DEFAULT N'113',
	--khoa
	sdt int NOT NULL DEFAULT 0123456789,
	status NVARCHAR(100) NOT NULL DEFAULT N'' -- đang thuê || chưa thuê
	
)
GO
CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Gia Lai',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff
)
GO

CREATE TABLE BookCategory -- danh mục sách
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Book
(
	id INT IDENTITY PRIMARY KEY,
	idCategory INT NOT NULL,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	quantity INT NOT NULL DEFAULT 1,
	releaseYear INT NOT NULL DEFAULT N'2018',
	nameAuthor NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	nameNXB NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	price FLOAT NOT NULL DEFAULT 0,
	bookPic NVARCHAR(100) NOT NULL DEFAULT N'name_content_author.png'

	FOREIGN KEY (idCategory) REFERENCES dbo.BookCategory(id)
	
)
GO

CREATE TABLE Book_Storage 
(
	id INT IDENTITY PRIMARY KEY,
	idStorage INT NOT NULL,

	FOREIGN KEY(idStorage) REFERENCES dbo.Book(id)
)
GO


CREATE TABLE Rent
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idStudent INT NOT NULL,
	status INT NOT NULL DEFAULT 0 
	
	FOREIGN KEY (idStudent) REFERENCES dbo.Student(id)
)
GO

CREATE TABLE RentInfo
(
	id INT IDENTITY PRIMARY KEY,
	idRent INT NOT NULL,
	idBook INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idRent) REFERENCES dbo.Rent(id),
	FOREIGN KEY (idBook) REFERENCES dbo.Book(id)
)
GO
--**************************************************************************************************
-- PROCEDURE secsion
--**************************************************************************************************

--xử lý đăng nhập

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO





--**************************************************************************************************
-- INSERT secsion
--**************************************************************************************************

INSERT INTO dbo.Account( UserName , DisplayName ,PassWord ,Type)
VALUES  ( N'GiaLai' , N'Admin' , N'123' , 1)
GO


INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Light novel')
INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Manga' )
INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Công nghệ thông tin' )
INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Doujinshi' )
INSERT dbo.BookCategory( name )VALUES  ( N'Văn học')
GO

INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
VALUES  ( N'Toaru majutsu no Index' ,1 ,2018 ,N'Kamachi Kazuma' ,N'IBM' ,105000.0)
INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
VALUES  ( N'Toaru Kagaku no Railgun' ,2 ,2018 ,N'Kamachi Kazuma' ,N'Kim Đồng' ,85000.0 )
INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
VALUES  ( N'Toaru Kagaku no Accelerator' ,2 ,2018 ,N'Kamachi Kazuma' ,N'Kim Đồng' ,85000.0)
INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
VALUES  ( N'Fate/Strange fake' ,4 ,2018 ,N'Narita Ryohgo, Morii Shizuki' ,N'Kim Đồng' ,105000.0)
INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
VALUES  ( N'Mạng máy tính' ,3 ,2018 ,N'Mai Trang' ,N'Ou Universe' ,9999999.0 )
INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
VALUES  ( N'Kiến trúc máy tính' ,3 ,2018 ,N'Tô Oai Hùng' ,N'Ou Universe' ,99999999.0)
INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
VALUES  ( N'Cô gái văn chương' ,5 ,2011 ,N'Nomura Mizuki' ,N'Kim Đồng' , 89000.0)
GO
--UPDATE dbo.Book SET name = N'' , idCategory = 5 , releaseYear = 2018 , nameAuthor = N'' , nameNXB = N'', price = 1000 WHERE id = 1

SET IDENTITY_INSERT dbo.Book ON
--insert here
SET IDENTITY_INSERT dbo.Book OFF
GO



--**************************************************************************************************
-- TABLE secsion
--**************************************************************************************************

--DECLARE @i INT = 0
--WHILE @i <= 10
--BEGIN
--	INSERT dbo.Student( name, mssv, status )VALUES  ( N'', N'',N'' + CAST(@i AS NVARCHAR(100))
--END
--GO

--**************************************************************************************************
