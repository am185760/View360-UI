USE [View360]
GO

/****** Object:  StoredProcedure [dbo].[LoadServersInfo]    Script Date: 2/19/2023 2:06:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <19/02/2023>
-- =============================================
create PROCEDURE [dbo].[LoadServersInfo] 
AS
BEGIN
	SET NOCOUNT ON;
	select ServersInfo from app_setting;
END
GO


