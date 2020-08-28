--Project Session 2
use master
go
create database Session2
--on primary(
--	name = N'Session2_dat',
--	filename = N'D:\Documents\.NET\Bai Tap Lon\SQL\Session2.mdf',
--	size = 10MB,
--	maxsize = unlimited,
--	filegrowth = 3MB
--)
--log on(
--	name = N'Session2_log',
--	filename = N'D:\Documents\.NET\Bai Tap Lon\SQL\Session2.ldf',
--	size = 5MB,
--	maxsize = unlimited,
--	filegrowth = 1MB
--)
go
use Session2
--AssetGroups
create table AssetGroups(
	ID bigint identity(1,1) not null,
	Name nvarchar(50) not null
	constraint PK_AssetGroups primary key(ID)
)
go
--Employees
create table Employees(
	ID bigint identity(1,1) not null,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Phone nvarchar(50) not null,
	isAdmin bit null,
	Username nvarchar(50) null,
	Password nvarchar(50) null,
	constraint PK_Employess primary key(ID)
)
go
--Departments
create table Departments(
	ID bigint identity(1,1) not null,
	Name nvarchar(100) not null,
	constraint PK_Departments primary key(ID)
)
go
--Locations
create table Locations(
	ID bigint identity(1,1) not null,
	Name nvarchar(100) not null,
	constraint PK_Locations primary key(ID)
)
go
--Priorities
create table Priorities(
	ID bigint identity(1,1) not null,
	Name nvarchar(100) not null,
	constraint PK_Priorities primary key(ID)
)
go
--Parts
create table Parts(
	ID bigint identity(1,1) not null,
	Name nvarchar(100) not null,
	EffectiveLife bigint null,
	constraint PK_Parts primary key(ID)
)
go
--DepartmentLocations
create table DepartmentLocations(
	ID bigint identity(1,1) not null,
	DepartmentID bigint not null,
	LocationID bigint not null,
	StartDate date not null,
	EndDate date null
	constraint PK_DepartmentLocations primary key(ID)
	constraint FK1_DepartmentLocations_Departments foreign key(DepartmentID) references Departments(ID),
	constraint FK2_DepartmentLocations_Locations foreign key(LocationID) references Locations(ID),
)
go
--Assets
create table Assets(
	ID bigint identity(1,1) not null,
	AssetSN nvarchar(20) not null,
	AssetName nvarchar(150) not null,
	DepartmentLocationID bigint not null,
	EmployeeID bigint not null,
	AssetGroupID bigint not null,
	Description nvarchar(2000) not null,
	WarrantyDate date null,
	constraint PK_Assets primary key(ID),
	constraint FK1_Assets_AssetsGroups foreign key(AssetGroupID) references AssetGroups(ID),
	constraint FK2_Assets_DepartmentLocations foreign key(DepartmentLocationID) references DepartmentLocations(ID),
	constraint FK3_Assets_Employees foreign key(EmployeeID) references Employees(ID),
)
go
--EmergencyMaintenances
create table EmergencyMaintenances(
	ID bigint identity(1,1) not null,
	AssetID bigint not null,
	PriorityID bigint not null,
	DescriptionEmergency nvarchar(200) not null,
	OtherConsiderations nvarchar(200) not null,
	EMReportDate date not null,
	EMStartDate date null,
	EMEndDate date null,
	EMTechnicianNote nvarchar(200) null,
	constraint PK_EmergencyMaintenances primary key(ID),
	constraint FK1_EmergencyMaintenances_Assets foreign key(AssetID) references Assets(ID),
	constraint FK2_EmergencyMaintenances_Priorities foreign key(PriorityID) references Priorities(ID)
)
go
--ChangedParts
create table ChangedParts(
	ID bigint identity(1,1) not null,
	EmergencyMaintenanceID bigint not null,
	PartID bigint not null,
	Amount decimal(18, 2) not null,
	constraint PK_ChangedParts primary key (ID),
	constraint FK1_ChangedParts_EmergencyMaintenances foreign key(EmergencyMaintenanceID) references EmergencyMaintenances(ID),
	constraint FK1_ChangedParts_Parts foreign key(PartID) references Parts(ID)
)
go
--INSERT DATA
go
--AssetGroup
set identity_insert AssetGroups on --bật tắt thuộc tính identity
insert into AssetGroups(ID, Name) values(1, N'Hydraulic'),
							(2, N'Pneumatic'),
							(3, N'Electrical'),
							(4, N'Mechanical '),
							(5, N'Fixed/Stationary'),
							(6, N'Facility'),
							(7, N'Buildings')

set identity_insert AssetGroups off
go
--Employees
set identity_insert Employees on
insert into Employees(ID, FirstName, LastName, Phone, isAdmin, Username, Password) values(1, N'Martina', N'Winegarden', N'69232044381', NULL, NULL, NULL),
							(2, N'Rashida', N'Brammer', N'70687629632', NULL, NULL, NULL),
							(3, N'Mohamed', N'Krall', N'52688435003', NULL, N'mohamed', N'1234'),
							(4, N'Shante', N'Karr', N'73706803851', NULL, NULL, NULL),
							(5, N'Rosaura', N'Rames', N'70477806324', NULL, NULL, NULL),
							(6, N'Toi', N'Courchesne', N'37756763508', NULL, NULL, NULL),
							(7, N'Precious', N'Wismer', N'15287468908', NULL, NULL, NULL),
							(8, N'Josefa', N'Otte', N'68886927765', NULL, N'josefa', N'1324'),
							(9, N'Afton', N'Harrington', N'41731972558', NULL, NULL, NULL),
							(10, N'Daphne', N'Morrow', N'49099375842', NULL, NULL, NULL),
							(11, N'Dottie', N'Polson', N'91205317719', NULL, NULL, NULL),
							(12, N'Alleen', N'Nally', N'26312971918', NULL, NULL, NULL),
							(13, N'Hilton', N'Odom', N'66197770749', NULL, NULL, NULL),
							(14, N'Shawn', N'Hillebrand', N'64091780262', NULL, NULL, NULL),
							(15, N'Lorelei', N'Kettler', N'73606665126', NULL, NULL, NULL),
							(16, N'Jalisa', N'Gossage', N'10484197749', NULL, NULL, NULL),
							(17, N'Germaine', N'Sim', N'62454794026', NULL, NULL, NULL),
							(18, N'Suzanna', N'Wollman', N'97932678482', NULL, NULL, NULL),
							(19, N'Jennette', N'Besse', N'26229712670', NULL, NULL, NULL),
							(20, N'Margherita', N'Anstine', N'87423893204', NULL, NULL, NULL),
							(21, N'Earleen', N'Lambright', N'64658700776', NULL, NULL, NULL),
							(22, N'Lyn', N'Valdivia', N'32010885662', 1, N'lyn', N'1234'),
							(23, N'Alycia', N'Couey', N'41716866650', NULL, NULL, NULL),
							(24, N'Lewis', N'Rousey', N'16716397946', NULL, NULL, NULL),
							(25, N'Tanja', N'Profitt', N'77230010211', NULL, NULL, NULL),
							(26, N'Cherie', N'Whyte', N'33510813739', NULL, NULL, NULL),
							(27, N'Efren', N'Leaf', N'72090665294', NULL, NULL, NULL),
							(28, N'Delta', N'Darcangelo', N'73136120450', NULL, NULL, NULL),
							(29, N'Jess', N'Bodnar', N'12207277240', NULL, NULL, NULL),
							(30, N'Sudie', N'Parkhurst', N'26842289705', NULL, NULL, NULL)
set identity_insert Employees off
go
--Departments
set identity_insert Departments on
insert into Departments(ID, Name) values(1, N'Exploration'),
							(2, N'Production'),
							(3, N'Transportation'),
							(4, N'R&D'),
							(5, N'Distribution'),
							(6, N'QHSE')
set identity_insert Departments off
go
--Locations
set identity_insert Locations on
insert into Locations(ID, Name) values(1, N'Kazan'),
							(2, N'Volka'),
							(3, N'Moscow')
set identity_insert Locations off
go
--Priorities
set identity_insert Priorities on
insert into Priorities(ID, Name) values(1, N'General'),
							(2, N'High'),
							(3, N'Very High')
set identity_insert Priorities off
go
--Parts
set identity_insert Parts on
insert into Parts(ID, Name, EffectiveLife) values(1, N'BLUE STORM Battery 12V 45Ah 54459', 650),
						(2, N'BLUE STORM Battery 12V 70Ah 80D26L', 700),
						(3, N'CT20 Turbo Turbocharger', NULL),
						(5, N'michelin tyres   525/60 ZR 20.5', 1000),
						(6, N'MOCA Engine Timing Chain Kit ', NULL),
						(7, N'CT16V Turbo Cartridge Core', NULL),
						(8, N'iFJF 21100-35520 New Carburetor', NULL),
						(9, N'ALAVENTE 21100-35463 Carburetor ', NULL),
						(11, N'Carter P4594 In-Line Electric Fuel Pump', NULL),
						(12, N'Electric Fuel Pump Universal Fuel Pump 12V ', NULL),
						(13, N'Gast AT05 Rotary Vane ', NULL),
						(14, N'FAN 24" M480', 200)
set identity_insert Parts off
go
--DepartmentLocations
set identity_insert DepartmentLocations on
insert into DepartmentLocations(ID, DepartmentID, LocationID, StartDate, EndDate) values(1, 6, 3, CAST(N'2010-12-28' AS Date), CAST(N'2011-01-20' AS Date)),
										(2, 6, 2, CAST(N'2015-12-27' AS Date), CAST(N'2019-08-20' AS Date)),
										(3, 5, 2, CAST(N'1996-04-29' AS Date), NULL),
										(4, 5, 1, CAST(N'2002-03-04' AS Date), NULL),
										(5, 5, 1, CAST(N'1991-03-25' AS Date), CAST(N'2001-10-30' AS Date)),
										(6, 4, 3, CAST(N'2012-05-28' AS Date), NULL),
										(7, 4, 2, CAST(N'2005-05-04' AS Date), NULL),
										(8, 3, 2, CAST(N'1992-10-17' AS Date), NULL),
										(9, 3, 3, CAST(N'2000-01-08' AS Date), NULL),
										(10, 2, 1, CAST(N'1993-12-25' AS Date), NULL),
										(11, 1, 2, CAST(N'2005-11-11' AS Date), NULL),
										(12, 1, 2, CAST(N'1991-01-17' AS Date), CAST(N'2000-02-02' AS Date))
set identity_insert DepartmentLocations off
go
--Assets
set identity_insert Assets on
insert into Assets(ID, AssetSN, AssetName, DepartmentLocationID, EmployeeID, AssetGroupID, Description, WarrantyDate)
						values (1, N'05/04/0001', N'Toyota Hilux FAF321', 3, 8, 4, N'', NULL),
						(2, N'04/03/0001', N'Suction Line 852', 7, 8, 3, N'', CAST(N'2020-03-02' AS Date)),
						(3, N'01/01/0001', N'ZENY 3,5CFM Single-Stage 5 Pa Rotary Vane', 11, 1, 1, N'', CAST(N'2018-01-17' AS Date)),
						(4, N'05/04/0002', N'Volvo FH16', 4, 8, 4, N'', NULL)
set identity_insert Assets off
go
--EmergencyMaintenances
set identity_insert EmergencyMaintenances on
insert into EmergencyMaintenances(ID, AssetID, PriorityID, DescriptionEmergency, OtherConsiderations, EMReportDate,EMStartDate, EMEndDate, EMTechnicianNote)
										values (1, 1, 2, N'Car does not start', N'none', CAST(N'2019-08-27' AS Date), CAST(N'2019-08-27' AS Date), NULL, NULL),
										(2, 2, 1, N'Perforated tire', N'none', CAST(N'2019-08-27' AS Date), CAST(N'2019-08-27' AS Date), NULL, NULL),
										(3, 4, 3, N'Preforated tire', N'none', CAST(N'2017-09-29' AS Date), CAST(N'2017-09-29' AS Date), CAST(N'2017-09-29' AS Date), N'The tire changed'),
										(4, 4, 3, N'Preforated tire', N'none', CAST(N'2018-09-29' AS Date), CAST(N'2018-09-29' AS Date), CAST(N'2018-09-29' AS Date), N'The tire changed'),
										(5, 3, 1, N'Perforated tire', N'none', CAST(N'2019-08-27' AS Date), CAST(N'2019-08-27' AS Date), NULL, NULL)
set identity_insert EmergencyMaintenances off
go
--ChangedParts
set identity_insert ChangedParts on
insert into ChangedParts(ID, EmergencyMaintenanceID, PartID, Amount) values (1, 3, 5, CAST(1.00 AS Decimal(18, 2))),
								(2, 1, 1, CAST(1.00 AS Decimal(18, 2)))
set identity_insert ChangedParts off
go
--SELECT
go
select * from AssetGroups
select * from Employees
select * from Departments
select * from Locations
select * from Priorities
select * from Parts
select * from DepartmentLocations
select * from Assets
select * from EmergencyMaintenances
select * from ChangedParts