USE [View360]
GO

/****** Object:  StoredProcedure [dbo].[GetUnassignedAtms]    Script Date: 3/19/2023 12:31:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <16/03/2023>
-- Description:	<get all atms that not assigned to server yet>
-- =============================================
CREATE PROCEDURE [dbo].[GetUnassignedAtms] 
AS
BEGIN
	SET NOCOUNT ON;
	Select * from atm where assigned_server is null;
END
GO


