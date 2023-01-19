CREATE DATABASE Holidays
GO

USE Holidays

/* Script Tabela */

CREATE TABLE [dbo].[NationalHolidays](
    [NationalHolidayId] [INTEGER] IDENTITY (1,1) PRIMARY KEY,
	[Date] [VARCHAR](5) NULL,
	[Title] [VARCHAR](100) NOT NULL,
	[Description] [VARCHAR](250) NOT NULL,
	[Legislation] [VARCHAR](250) NOT NULL,
	[Type] [VARCHAR](10) NOT NULL,
	[StartTime] [VARCHAR](50) NULL,
	[EndTime] [VARCHAR](50) NULL
)

GO

/* Script Stored Procedures */

CREATE PROCEDURE [dbo].[SP_GET_NationalHolidayById]
(
    @NationalHolidayId INTEGER
)

AS

SELECT
    NationalHolidays.NationalHolidayId,
	NationalHolidays.Date,
	NationalHolidays.Title,
	NationalHolidays.Description,
	NationalHolidays.Legislation,
	NationalHolidays.Type,
	NationalHolidays.StartTime,
	NationalHolidays.EndTime
FROM
	NationalHolidays
WHERE
    NationalHolidays.NationalHolidayId = @NationalHolidayId
GO

CREATE PROCEDURE [dbo].[SP_LST_NationalHolidays]

AS

SELECT
    NationalHolidays.NationalHolidayId,
	NationalHolidays.Date,
	NationalHolidays.Title,
	NationalHolidays.Description,
	NationalHolidays.Legislation,
	NationalHolidays.Type,
	NationalHolidays.StartTime,
	NationalHolidays.EndTime
FROM
	NationalHolidays

GO

CREATE PROCEDURE [dbo].[SP_DEL_NationalHolidayById]
(
    @NationalHolidayId INTEGER
)

AS

DELETE 
FROM 
    NationalHolidays
WHERE
    NationalHolidays.NationalHolidayId = @NationalHolidayId

GO

CREATE PROCEDURE [dbo].[SP_DEL_NationalHolidays]

AS

DELETE FROM NationalHolidays

GO

CREATE PROCEDURE [dbo].[SP_ADD_NationalHoliday]
(
	@Date [VARCHAR](5) = NULL,
	@Title [VARCHAR](100),
	@Description [VARCHAR](250),
	@Legislation [VARCHAR](250),
	@Type [VARCHAR](10),
	@StartTime [VARCHAR](50) = NULL,
	@EndTime [VARCHAR](50) = NULL
)

AS

INSERT INTO NationalHolidays
(
	NationalHolidays.Date,
	NationalHolidays.Title,
	NationalHolidays.Description,
	NationalHolidays.Legislation,
	NationalHolidays.Type,
	NationalHolidays.StartTime,
	NationalHolidays.EndTime
)
VALUES
(
    @Date,
	@Title,
	@Description,
	@Legislation,
	@Type,
	@StartTime,
	@EndTime
)

GO

CREATE PROCEDURE [dbo].[SP_UPD_NationalHoliday]
(
    @NationalHolidayId [INTEGER],
	@Description [VARCHAR](250)
)

AS

UPDATE 
    NationalHolidays
SET 
	NationalHolidays.Description = 	@Description
WHERE
    NationalHolidays.NationalHolidayId = @NationalHolidayId

GO