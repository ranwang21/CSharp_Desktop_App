USE master

IF EXISTS (SELECT * FROM master.sys.databases WHERE name='DbTP')
BEGIN
  RAISERROR('Dropping existing DbTP database ....',0,1)
  DROP DATABASE DbTP
END
GO

PRINT 'Cr閍tion de la base de donn閑 DbTP'
CREATE DATABASE DbTP
GO

USE DbTP

CREATE TABLE Student(
	Id_Student smallint NOT NULL UNIQUE,
	Gender char(1) NOT NULL,
	FirstName varchar(25) NOT NULL,
	LastName varchar(25) NOT NULL,
	Birthday datetime NULL,
	Adress varchar(50) NULL,
	Phone varchar(25) NULL,
	Email varchar(50) NULL,
	CONSTRAINT PK_Id_Student PRIMARY KEY (Id_Student)
)

insert into Student values (101,'H','Marco','Renchez','19980503','123 Champs-de-ble', '(514)456-9892', 'MRenchez@gmail.com')
insert into Student values (102,'F','Raphaelle','Tremblay','19980723','573 Dubois', '(438)321-5739', 'RaphyTremblay@outlook.fr')
insert into Student values (103,'H','Jan','Wing','19961125','5839 Silou', '(514)838-0275', 'WingJan@hotmail.com')

CREATE TABLE Connexion(
	Username varchar(25) NOT NULL,
	MotDePasse varchar(25) NOT NULL
	CONSTRAINT PK_User_Password PRIMARY KEY(Username, MotDePasse)
)

insert into Connexion values ('yayeet', 'yeet')

SELECT *
FROM Connexion