USE employeesDb
go
-- GetAllEmployees --
CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
SET NOCOUNT ON;
    SELECT * 
    FROM [Employees]
    WHERE [IsDeleted] = 0
END;
go

-- GetById --
CREATE PROCEDURE [dbo].[GetEmployeeById]
    @EmployeeId uniqueidentifier
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * 
    FROM [Employees]
    WHERE [Id] = @EmployeeId
    AND [IsDeleted] = 0
END;
go

-- InsertEmployee --
CREATE PROCEDURE [dbo].[InsertEmployee]
    @Id uniqueidentifier,
    @Names nvarchar(80),
    @LastNames nvarchar(80),
    @IdentificationNumber nvarchar(20),
    @BirthDate date,
    @EntryDate date,
    @Salary float,
    @IdentificationTypeId int,
    @DepartmentId int,
    @CreatedBy nvarchar(50),
    @CreationDate datetime
AS
BEGIN
    INSERT INTO [employeesDb].[dbo].[Employees] (
        [Id],
        [Names],
        [LastNames],
        [IdentificationNumber],
        [BirthDate],
        [EntryDate],
        [Salary],
        [IdentificationTypeId],
        [DepartmentId],
        [CreatedBy],
        [CreationDate],
        [IsDeleted],
        [ModificationBy],
        [ModificationDate]
    )
    VALUES (
        @Id,
        @Names,
        @LastNames,
        @IdentificationNumber,
        @BirthDate,
        @EntryDate,
        @Salary,
        @IdentificationTypeId,
        @DepartmentId,
        @CreatedBy,
        @CreationDate,
        0,
        NULL,
        NULL
    );
END;
go

-- UpdateEmployee --
CREATE PROCEDURE [dbo].[UpdateEmployee]
    @Id uniqueidentifier,
    @Names nvarchar(50),
    @LastNames nvarchar(50),
    @IdentificationNumber nvarchar(20),
    @BirthDate date,
    @EntryDate date,
    @Salary float,
    @IdentificationTypeId int,
    @DepartmentId int,
    @ModificationBy nvarchar(50),
    @ModificationDate datetime
AS
BEGIN
    UPDATE [employeesDb].[dbo].[Employees]
    SET
        [Names] = @Names,
        [LastNames] = @LastNames,
        [IdentificationNumber] = @IdentificationNumber,
        [BirthDate] = @BirthDate,
        [EntryDate] = @EntryDate,
        [Salary] = @Salary,
        [IdentificationTypeId] = @IdentificationTypeId,
        [DepartmentId] = @DepartmentId,
        [ModificationBy] = @ModificationBy,
        [ModificationDate] = @ModificationDate
    WHERE [Id] = @Id;
END;
go

--DeleteEmployee--
CREATE PROCEDURE [dbo].[DeleteEmployee]
    @EmployeeId uniqueidentifier
AS
BEGIN
    UPDATE [employeesDb].[dbo].[Employees]
    SET
        [IsDeleted] = 1
    WHERE [Id] = @EmployeeId
END;
