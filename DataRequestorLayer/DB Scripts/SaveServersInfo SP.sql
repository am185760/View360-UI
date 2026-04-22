USE [View360]
GO

/****** Object:  StoredProcedure [dbo].[SaveServersInfo]    Script Date: 2/19/2023 2:08:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <19/02/2023>
-- =============================================
CREATE PROCEDURE [dbo].[SaveServersInfo] 
	@Info varbinary(max)
AS
BEGIN
	SET NOCOUNT ON;
	update app_setting set ServersInfo = @Info;
	select @@ROWCOUNT;
END
GO


