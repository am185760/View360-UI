USE [View360]
GO

/****** Object:  StoredProcedure [dbo].[AddOrUpdateTask]    Script Date: 3/13/2023 9:35:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <08/02/2023>
-- =============================================
CREATE PROCEDURE [dbo].[AddOrUpdateTask]
	@task_id int,
	@parsed bit,
	@bytes_sent int,
	@file_name varchar(max) = '',
	@Atm_Id int = 0,
	@file_type_id int = 0,
	@creation_time datetime = '',
	@download_time datetime = '',
	@end_time datetime,
	@status varchar(max),
	@user int = 0,
	@unZip_file_size int,
	@retry_count int,
	@task_type int = 0,
	@StatementType varchar(max),
	@cashDB varchar(max),
	@txDB varchar(max)
AS
  BEGIN

Declare @sql varchar(max);
--Declare @getMaxId nvarchar(max);
--Declare @maxTaskID int;
Declare @selectedDB varchar(max);

	IF @file_type_id = 1
		set @selectedDB = @cashDB + '.dbo.task';
	IF @file_type_id != 1
		set @selectedDB = @txDB + '.dbo.task';

	IF @StatementType = 'Insert'
	BEGIN
		--set @getMaxId =  N'select @maxTaskID = max(task_id) from ' + @selectedDB
		--EXEC SP_EXECUTESQL @getMaxId, N'@maxTaskID int OUTPUT', @maxTaskID OUTPUT;

		--if @maxTaskID is null
		--	set @maxTaskID = 0;
		--set @maxTaskID = @maxTaskID +1;

		set @sql = N'insert into ' + @selectedDB + ' (parsed,bytes_transferred,file_path_at_ATM,ATM_id,file_type_id,creation_time,download_time,end_time,status,created_by,unZipped_file_size,retry_Remaining,task_type_id)
		values (' + Cast(@parsed as varchar(max)) + ','+ Cast(@bytes_sent as varchar(max)) + ',''' + @file_name + ''',' 
		+ Cast(@Atm_Id as varchar(max)) + ',' + Cast(@file_type_id as varchar(max)) + ',
		convert(datetime,CONVERT(varchar,''' + Cast(@creation_time as varchar(max)) + ''',121),121),
		convert(datetime,CONVERT(varchar,'''+ Cast(@download_time as varchar(max)) + ''',121),121),
		convert(datetime,CONVERT(varchar,''' + Cast(@end_time as varchar(max)) + ''',121),121),'''
		+ @status + ''',' + Cast(@user as varchar(max)) + ',' + Cast(@unZip_file_size as varchar(max)) + ',' + Cast(@retry_count as varchar(max)) + ',' + Cast(@task_type as varchar(max)) +');'
		Exec(@sql);
		select @@IDENTITY;
		--set @sql = N'SELECT task_id from ' + @selectedDB + ' where task_id = ' + Cast(@maxTaskID as varchar(max))
		--Exec (@sql);
	END
	IF @StatementType = 'Update'
	BEGIN
		set @sql = N'UPDATE ' + @selectedDB +
		' SET    parsed=' + Cast(@parsed as varchar(max)) + ',
			bytes_transferred =bytes_transferred + ' + Cast(@bytes_sent as varchar(max)) + ',
			end_time= convert(datetime,CONVERT(varchar,''' + Cast(@end_time as varchar(max)) + ''',121),121),
			status= ''' + Cast(@status as varchar(max)) + ''',
			unZipped_file_size=unZipped_file_size + ' + Cast(@unZip_file_size as varchar(max)) + ',
			retry_Remaining=' + Cast(@retry_count as varchar(max)) + '
		 WHERE  task_id = ' + Cast(@task_id as varchar(max))
		Exec(@sql);
		select @@ROWCOUNT;
	END
  END
GO


