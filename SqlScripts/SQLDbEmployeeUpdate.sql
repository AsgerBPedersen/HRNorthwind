USE [Northwind]
GO
CREATE TABLE [dbo].[ContactInfos](
	[ContactInfoId] [int] PRIMARY KEY IDENTITY(1,1),
	[EmployeeId] [int] NOT NULL,
	[Email] [nvarchar](60) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[Country] [nvarchar](15) NULL,
	[WorkPhone] [nvarchar](24) NULL,
	[HomePhone] [nvarchar](24) NULL,
	[Extension] [nvarchar](4) NULL
 CONSTRAINT [FK_CONTACT_EMPLOYEEID] FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
)
GO
CREATE TABLE [dbo].[Employments](
	[EmploymentId] [int] PRIMARY KEY IDENTITY(1,1),
	[EmployeeId] [int] NOT NULL,
	[Title] [nvarchar](30) NULL,
	[HireDate] [datetime] NULL,
	[LeaveDate] [datetime] NULL
 CONSTRAINT [FK_EMPLOYMENT_EMPLOYEEID] FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
)
GO
INSERT INTO Employments(EmployeeID, Title, HireDate) 
SELECT EmployeeID, Title, HireDate from Employees;
GO
INSERT INTO ContactInfos(EmployeeID, Address, City, Region, Country, HomePhone, Extension) 
SELECT EmployeeID, Address, City, Region, Country, HomePhone, Extension from Employees;
GO
ALTER table Employees
drop column Hiredate, Address, City, Region, Country, HomePhone, Extension;
go
ALTER table Employees
add [Initials] [nvarchar](4) NULL;
go
