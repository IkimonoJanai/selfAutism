--C:\Users\Beosama\Desktop\Study\colledge\Kiểm thử phần mềm\DemoDATABASE
USE master
Go
DROP DATABASE DemoQuanLyThuVienAlphaVer2_1
GO
IF DB_ID('DemoQuanLyThuVienAlphaVer1_4') IS NULL 
	CREATE DATABASE DemoQuanLyThuVienAlphaVer2_1
GO


USE DemoQuanLyThuVienAlphaVer2_1
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

--21/11/2018
--Fix 
--TABLE
--student
--rent
--rentInfo => rentPay

----detail----
--

CREATE TABLE Student
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Học sinh chưa có tên',
	mssv NVARCHAR(100) NOT NULL DEFAULT N'113',
	--khoa
	sdt int NOT NULL DEFAULT 0123456789
	--status NVARCHAR(100) NOT NULL DEFAULT N'' -- đang thuê || chưa thuê	
)
GO

CREATE TABLE Account
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	UserName NVARCHAR(100) NOT NULL DEFAULT N'',	
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Gia Lai-san no waruko',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff
)
GO

CREATE TABLE BookCategory -- danh mục sách
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Book
(
	id INT IDENTITY(1,1) PRIMARY KEY,
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
	idBook INT NOT NULL,
	idStudent INT NOT NULL,
	idNhanVien INT NOT NULL,
	SLbook INT NOT NULL,
	DateRent DATE NOT NULL DEFAULT GETDATE(),
	DateRentPay DATE NOT NULL,
	
	status INT NOT NULL DEFAULT 0 
	
	FOREIGN KEY (idStudent) REFERENCES dbo.Student(id),
	FOREIGN KEY (idBook) REFERENCES dbo.Book(id),
	FOREIGN KEY (idNhanVien) REFERENCES dbo.Account(id)
)
GO

GO
CREATE TABLE RentPay
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idRent INT NOT NULL,
	idBook INT NOT NULL,
	idStudent INT NOT NULL,
	DatePay DATE NOT NULL,
	ifBreak INT NOT NULL,
	ifOutDate INT NOT NULL,
	PayMoney INT NOT NULL
	FOREIGN KEY (idRent) REFERENCES dbo.Rent(id),
	FOREIGN KEY (idBook) REFERENCES dbo.Book(id),
	FOREIGN KEY (idStudent) REFERENCES dbo.Student(id)
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

INSERT INTO dbo.Account( UserName ,DisplayName ,PassWord ,Type)
VALUES  ( N'GiaLai' ,N'Admin' ,N'123' ,1)
INSERT INTO dbo.Account( UserName ,DisplayName ,PassWord ,Type)
VALUES  (N'1651010045' ,N'Nguyễn Minh Đức' ,N'123' ,0)

--DELETE dbo.Account WHERE id = 3
--GO
GO

INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Light novel')
INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Manga' )
INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Công nghệ thông tin' )
INSERT	INTO dbo.BookCategory( name )VALUES  ( N'Doujinshi' )
INSERT dbo.BookCategory( name )VALUES  ( N'Văn học')
GO

INSERT dbo.Book( idCategory ,name ,quantity ,releaseYear ,nameAuthor ,nameNXB ,price ,bookPic)
VALUES  ( 1 ,N'Toaru majutsu no Index' ,500 ,2018 ,N'Kamachi Kazuma' ,N'IBM' ,80000.0 ,N'LN_Index_1.jpg')
INSERT dbo.Book( idCategory ,name ,quantity ,releaseYear ,nameAuthor ,nameNXB ,price ,bookPic)
VALUES  ( 1 ,N'Toaru majutsu no Index2' ,500 ,2018 ,N'Kamachi Kazuma' ,N'IBM' ,80000.0 ,N'LN_Index_2.jpg')

INSERT dbo.Book(idCategory ,name ,quantity ,releaseYear ,nameAuthor ,nameNXB ,price ,bookPic)
VALUES  (2 ,N'Toaru Kagaku no Railgun' ,500 ,2018 ,N'Nhiều tác giả' , N'Kim Đồng' ,89999.0 ,N'404 Not Found')
INSERT dbo.Book(idCategory ,name ,quantity ,releaseYear ,nameAuthor ,nameNXB ,price ,bookPic)
VALUES  (3 ,N'Mạng máy tính' ,50 ,2018 ,N'Tô Oai Hùng' , N'OU University' ,33333.0 ,N'404 Not Found')

INSERT dbo.Book(idCategory ,name ,quantity ,releaseYear ,nameAuthor ,nameNXB ,price ,bookPic)
VALUES  (4 ,N'Fate/Strange fake' ,200 ,2018 ,N'Nhiều tác giả' , N'Vô Diện' ,66666.0 ,N'404 Not Found')

INSERT dbo.Book(idCategory ,name ,quantity ,releaseYear ,nameAuthor ,nameNXB ,price ,bookPic)
VALUES  (5 ,N'Cô gái văn chương' ,999 ,2012 ,N'Nomura Mizuki' , N'Kim Đồng' ,55555.0 ,N'404 Not Found')
GO



--INSERT INTO dbo.Book( name ,idCategory ,releaseYear ,nameAuthor ,nameNXB ,price)
--VALUES  ( N'Toaru Kagaku no Accelerator' ,2 ,2018 ,N'Kamachi Kazuma' ,N'Kim Đồng' ,85000.0)

--GO
--UPDATE dbo.Book SET name = N'' , idCategory = 5 , releaseYear = 2018 , nameAuthor = N'' , nameNXB = N'', price = 1000 WHERE id = 1


INSERT dbo.Student( name, mssv, sdt )
VALUES  (N'Ứng Thành Long',N'165101001',0986208571 )
INSERT dbo.Student( name, mssv, sdt )
VALUES  (N'Đặng Hoàng Nhật Nam',N'165101002',0986208572 )
INSERT dbo.Student( name, mssv, sdt )
VALUES  (N'Lữ Hoàng Liêm',N'165101003',0986208573 )
GO

INSERT dbo.Rent(idBook ,idStudent ,idNhanVien ,SLbook ,DateRent ,DateRentPay ,status)
VALUES  (1 ,1, 1 ,5 ,N'2018-10-25' ,N'2018-10-30' ,DEFAULT)--N'2018-10-25', N'2018-10-30'
INSERT dbo.Rent(idBook ,idStudent ,idNhanVien ,SLbook ,DateRent ,DateRentPay ,status)
VALUES  (2 ,2, 1 ,5 ,N'2018-10-25' ,N'2018-10-30' ,DEFAULT)
--INSERT dbo.Rent(idBook ,idStudent ,idNhanVien ,SLbook ,DateRent ,DateRentPay ,status)
--VALUES  (3 ,3, 4 ,5 ,N'2018-10-25' ,N'2018-10-30' ,DEFAULT)--N'2018-10-25', N'2018-10-30'
GO
INSERT dbo.RentPay(idRent, idBook ,idStudent ,DatePay ,ifBreak ,ifOutDate ,PayMoney)
VALUES  (1 ,1 ,1 ,N'2018-10-31' ,5000 ,0 ,-45000 )
GO
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

CREATE FUNCTION [dbo].[fuConvertToUnsign1]
 ( 
	@strInput NVARCHAR(4000) 
 ) RETURNS NVARCHAR(4000) 
 AS 
 BEGIN 
	IF @strInput IS NULL 
		RETURN @strInput 
	IF @strInput = '' 
		RETURN @strInput 
	DECLARE @RT NVARCHAR(4000) 
	DECLARE @SIGN_CHARS NCHAR(136) 
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272)+ NCHAR(208)
	SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	DECLARE @COUNTER int 
	DECLARE @COUNTER1 int 
	SET @COUNTER = 1 
	WHILE (@COUNTER <=LEN(@strInput)) 
	BEGIN 
		SET @COUNTER1 = 1 
		WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
		BEGIN 
			IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
				BEGIN 
					IF @COUNTER=1 
						SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
					ELSE 
						SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
					BREAK 
				END 
			SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO


SELECT * FROM dbo.Account
SELECT * FROM dbo.Book
SELECT * FROM dbo.Rent
SELECT * FROM dbo.RentPay
SELECT * FROM dbo.Student
SELECT * FROM dbo.Book_Storage
GO

