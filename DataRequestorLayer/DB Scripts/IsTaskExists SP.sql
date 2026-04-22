USE [View360]
GO
/****** Object:  StoredProcedure [dbo].[IsTaskExists]    Script Date: 3/8/2023 11:43:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[IsTaskExists]    
@CreationDate datetime,      
@atmID int,
@taskTypeID int,
@cashDB varchar(max),
@txDB varchar(max) 
as       
BEGIN      
	set nocount on    
	DECLARE @SQL NVARCHAR(MAX)      
	Declare @selectedDB varchar(max);
	if(@taskTypeID = 1)
		set @selectedDB = @cashDB;
	else
		set @selectedDB = @txDB;

	set @SQL = N'select top(1)task_id from ' + @selectedDB +'.dbo.task with (nolock)   where creation_time >= convert(datetime,convert(varchar,'''+ Cast(@CreationDate as varchar(max)) + ''',121),121) 
	and creation_time < GETDATE()+1 and Atm_id =' + convert(varchar, @atmID ,121) + 'and file_type_id = ' + convert(varchar,@taskTypeID,121)
	Exec(@SQL);
 end