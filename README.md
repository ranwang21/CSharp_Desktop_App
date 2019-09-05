# CSharp_Desktop_App
This is a desktop app built on C# to make CRUD operations on student database on a GUI.
Techstack: C#, .Net framwork, ADO .NET, SQL Server, and WPF.

## install
You should create a **SQL Server** databse in your local machine with the following query:
```
USE master

IF EXISTS (SELECT * FROM master.sys.databases WHERE name='DbTP')
BEGIN
  RAISERROR('Dropping existing DbTP database ....',0,1)
  DROP DATABASE DbTP
END
GO

PRINT 'Creation de la base de donne DbTP'
CREATE DATABASE DbTP
GO

USE DbTP


CREATE TABLE Connexion(
    Username varchar(25) NOT NULL,
    MotDePasse varchar(25) NOT NULL
    CONSTRAINT PK_User_Password PRIMARY KEY(Username)
)

CREATE TABLE Student(
    Id_Student smallint NOT NULL UNIQUE,
    Gender char(1) NOT NULL,
    FirstName varchar(25) NOT NULL,
    LastName varchar(25) NOT NULL,
    Birthday datetime NULL,
    Adress varchar(50) NULL,
    Phone varchar(25) NULL,
    Email varchar(50) NULL,
    Prof varchar(25) NOT NULL,
    CONSTRAINT PK_Id_Student PRIMARY KEY (Id_Student),
    CONSTRAINT FK_Prof FOREIGN KEY (Prof) REFERENCES Connexion (Username),
)


insert into Connexion values ('yayeet', 'yeet')
insert into Connexion values ('bob', 'bob')
insert into Connexion values ('toto', 'toto')
insert into Connexion values ('titi', 'titi')
insert into Connexion values ('admin', 'admin')


insert into Student values (101,'H','Marco','Renchez','19980503','123 Champs-de-ble', '(514)456-9892', 'MRenchez@gmail.com','titi')
insert into Student values (102,'F','Raphaelle','Tremblay','19980723','573 Dubois', '(438)321-5739', 'RaphyTremblay@outlook.fr','bob')
insert into Student values (103,'H','Jan','Wing','19961125','5839 Silou', '(514)838-0275', 'WingJan@hotmail.com','titi')
insert into Student values (104,'F','Lilas','LaPlante','19970718','777 Yatusabe Av.', '(514)531-0275', 'lilas@yatusabe.com','bob')
insert into Student values (105,'H','Marcos','Yatusabe Jr.','19970509','289 boul. GG EZ ', '(438)678-0265', 'yatusabe@yatusabe.com','bob')
insert into Student values (106,'F','Gertrude','LaFontaine','19950819','2829 13 Av.', '(450)737-4265', 'Gertrude@LaFontaine.com','bob')
insert into Student values (107,'H','Stefano','Duvalio','19960715','510 boul. Coolio-Profio ', '(438)987-03260', 'Stefano@Duvalio.com','bob')
insert into Student values (108,'F','Julia','DuCoin','19991209','2389 boul. rip ', '(450)777-0265', 'Julia@DuCoin.com','titi')
insert into Student values (109,'H','Kiki','Skululu','19920329','28819  Oups Av.', '(438)747-0335', 'Kiki@Skrilili.com','titi')
insert into Student values (110,'F','Yeetus','Deletus','19941107','5987 Yeet street ', '(438)987-3540', 'Yeetus@BarGrillRestoBarGrills.com','bob')
insert into Student values (111,'F','Bayonetta','Pistolera','19941107','6840 Trans Street', '(438)572-2950', 'bayolera@hotmail.com','yayeet')
insert into Student values (112,'H','Bertrand','Junior','20091206','No. 10120', '(438)583-3920', 'bjunior123@outlook.fr','yayeet')
insert into Student values (113,'F','Lucy','Herfield','19970609','68 Boul. Enchanteur', '(438)103-0294', 'herfieldl@hotmail.com','yayeet')
insert into Student values (114,'H','George','Delajungle','20100801','5988 Yeet street ', '(438)583-0285', 'gdelaj@hotmail.com','toto')
insert into Student values (115,'H','Roger','Bord','19981205','5986 Yeet street ', '(438)111-6930', 'rogbord@hotmail.com','toto')
insert into Student values (116,'H','Manuel','Thompson','20000608','5985 Yeet street ', '(438)674-9104', 'manut@hotmail.com','toto')


SELECT *
FROM Connexion

SELECT *
FROM Student
```
Change the SQL Connection String in the **App.config**:
```
<add name="[YOUR MACHINE NAME]" connectionString="Data Source=[YOUR DATABASE];Initial Catalog=DbTP;User Id=[YOUR DATABASE USER NAME];Password=[YOUR DATABASE PASSWORD]"/>
```

## use
When the program starts, a login window appears, you can use one of the login/password to test the program, for example: `username: yayeet; password: yeet`.
