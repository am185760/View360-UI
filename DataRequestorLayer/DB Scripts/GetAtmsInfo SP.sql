USE [View360]
GO

/****** Object:  StoredProcedure [dbo].[GetAtmsInfo]    Script Date: 3/12/2023 11:23:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <09/03/2023>
-- =============================================
CREATE procedure [dbo].[GetAtmsInfo]    
@MaxAtms int,
@CoreDB varchar(max),
@OffsetRows int
as       
BEGIN      
	set nocount on    
	DECLARE @SQL NVARCHAR(MAX)

	set @SQL = N'select ATM_id,IP from ' + CAST(@CoreDB as varchar(max)) +  '.dbo.atm ORDER BY ATM_id asc
	OFFSET ' + CAST(@OffsetRows as varchar(max)) + ' ROWS FETCH NEXT ' + CAST(@MaxAtms as varchar(max)) + ' ROWS ONLY'
	Exec(@SQL);
 end
GO


