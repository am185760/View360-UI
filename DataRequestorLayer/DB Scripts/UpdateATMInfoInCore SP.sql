USE [View360]
GO
/****** Object:  StoredProcedure [dbo].[SaveATMInfo]    Script Date: 3/19/2023 2:05:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <19/03/2023>
-- Description:	<Update ATMs in Core DB with the assigned server number>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateATMInfoInCore] 
@AtmsID varchar(max),
@ServerNum int

AS
BEGIN
	SET NOCOUNT ON;
	declare @sql varchar(max);
	set @sql = N'update atm set assigned_server = ' + CAST(@ServerNum as varchar(max)) + ', is_edited = 0 where ATM_id in ('+ @AtmsID +')';
	Exec(@sql);
	select @@ROWCOUNT;
END
