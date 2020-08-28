--employees
select * from Employees
select AssetSN , AssetName , EMEndDate, Amount
                from Assets inner join EmergencyMaintenances on Assets.ID = EmergencyMaintenances.AssetID
                inner join ChangedParts on ChangedParts.EmergencyMaintenanceID = EmergencyMaintenances.ID
				inner join Employees on Employees.ID = Assets.EmployeeID
				where Employees.Username = N'josefa'




--reset tb
--EmergencyMaintenances
create table EmergencyMaintenances(
	ID bigint IDENTITY(1,1) not null,
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

insert into EmergencyMaintenances values ( 1, 2, N'Car does not start', N'none', CAST(N'20-Aug-20 12:00:00 AM' AS Date), CAST(N'2019-08-27' AS Date), NULL, NULL),
										( 4, 1, N'Perforated tire', N'none', CAST(N'2019-08-27' AS Date), CAST(N'2019-08-27' AS Date), NULL, NULL),
										( 4, 1, N'Preforated tire', N'none', CAST(N'2017-09-29' AS Date), CAST(N'2017-09-29' AS Date), CAST(N'2017-09-29' AS Date), N'The tire changed')
go

select * from EmergencyMaintenances
select * from Assets
--đăng kí yêu cầu bảo trì mới
insert into EmergencyMaintenances values ( 1, 2, N'Car does not start', N'none', CAST(N'2019-08-27' AS Date), CAST(N'2019-08-27' AS Date), NULL, NULL),


go
--getAssetID
select ID from Assets
where AssetSN = '' and AssetName = ''

--query của List of Asset Request
select Priorities.ID, AssetSN, AssetName, EMReportDate, CONCAT( Employees.FirstName,' ', Employees.LastName) as N'FullName', Priorities.Name,
                Departments.Name from Employees inner join Assets on Employees.ID = Assets.EmployeeID 
                inner join EmergencyMaintenances on EmergencyMaintenances.AssetID = Assets.ID
                inner join DepartmentLocations on DepartmentLocations.ID = Assets.DepartmentLocationID
                inner join Departments on Departments.ID = DepartmentLocations.DepartmentID
				inner join Priorities on Priorities.ID = EmergencyMaintenances.PriorityID
				order by  EMReportDate asc
				order by Priorities.ID desc
go

select * from Parts
select * from EmergencyMaintenances

go
select AssetName, Parts.Name, Parts.EffectiveLife,EmergencyMaintenances.EMReportDate , ChangedParts.Amount
from Parts inner join ChangedParts on Parts.ID = ChangedParts.PartID
	inner join EmergencyMaintenances on EmergencyMaintenances.ID = ChangedParts.EmergencyMaintenanceID
	inner join Assets on EmergencyMaintenances.AssetID = Assets.ID

	where AssetName = N'Volvo FH16' 

--kiểm tra pass thêm vào
select AssetName,Parts.ID, Parts.Name, Parts.EffectiveLife,EmergencyMaintenances.EMReportDate
from Parts inner join ChangedParts on Parts.ID = ChangedParts.PartID
	inner join EmergencyMaintenances on EmergencyMaintenances.ID = ChangedParts.EmergencyMaintenanceID
	inner join Assets on EmergencyMaintenances.AssetID = Assets.ID
	where Parts.ID = 6 or Parts.EffectiveLife > 0 and EmergencyMaintenances.EMReportDate = '2019-08-27'


select * from Assets
go
--lấy id
select EmergencyMaintenances.ID
from EmergencyMaintenances inner join Assets on EmergencyMaintenances.AssetID = Assets.ID
where AssetName = N'Volvo FH16' and EmergencyMaintenances.EMReportDate = '2019-08-27'

--insert changedpasrts
create table ChangedParts(
	ID bigint IDENTITY(1,1) not null,
	EmergencyMaintenanceID bigint not null,
	PartID bigint not null,
	Amount decimal(18, 2) not null,
	constraint PK_ChangedParts primary key (ID),
	constraint FK1_ChangedParts_EmergencyMaintenances foreign key(EmergencyMaintenanceID) references EmergencyMaintenances(ID),
	constraint FK1_ChangedParts_Parts foreign key(PartID) references Parts(ID)
)
go


INSERT INTO ChangedParts
OUTPUT inserted.ID
VALUES(3, 5, CAST(1.00 AS Decimal(18, 2)))

INSERT INTO ChangedParts
OUTPUT inserted.ID
VALUES(1, 1, CAST(1.00 AS Decimal(18, 2)))

delete from ChangedParts
----
insert into ChangedParts values(1,1,1);

select * from ChangedParts 

--delete from changedPart



select * from ChangedParts inner join Parts on ChangedParts.PartID = Parts.ID
select * from EmergencyMaintenances

delete from ChangedParts 
where ChangedParts.ID = (select ChangedParts.ID 
from Parts inner join ChangedParts on Parts.ID = ChangedParts.PartID
	inner join EmergencyMaintenances on EmergencyMaintenances.ID = ChangedParts.EmergencyMaintenanceID
	inner join Assets on EmergencyMaintenances.AssetID = Assets.ID
	where Parts.Name = N'FAN 24" M480' and EmergencyMaintenanceID = 4)

	--submit
--update EmergencyMaintenances
--set EMStartDate = '', EMEndDate = '', EMTechnicianNote = ''
--where ID = 

--check update
select * from EmergencyMaintenances

