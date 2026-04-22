USE [View360]
GO

/****** Object:  StoredProcedure [dbo].[SaveATMInfo]    Script Date: 3/19/2023 3:36:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <19/03/2023>
-- Description:	<Save bulk of ATM records into specific DB server>
-- =============================================
CREATE PROCEDURE [dbo].[SaveATMInfo] 
@AtmsInfo ATM_table_type readonly
AS
BEGIN
	SET NOCOUNT ON;
	insert into atm 
	select * from @AtmsInfo;

	select @@ROWCOUNT;
END
GO


