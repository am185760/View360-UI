USE [View360]
GO

/****** Object:  StoredProcedure [dbo].[AddOrUpdateCashDataTask]    Script Date: 3/7/2023 4:25:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Eslam Abdelaziz>
-- Create date: <08/02/2023>
-- =============================================
CREATE PROCEDURE [dbo].[AddOrUpdateCashDataTask]
	@taskId int,
	@fileCreationTime datetime = '',
	@generationTime datetime,
	@content varbinary(max),
	@StatementType varchar(max),
	@cashDB varchar(max),
	@txDB varchar(max),
	@isTx bit
AS
  BEGIN
  declare @sql varchar(max);
  declare @CashDataStoreDB varchar(50) = 'cashdatastore_' + Cast(Year(GetDate()) as varchar(50));
  declare @insertState varchar(max);
  declare @tblCol varchar(max);

	IF @isTx = 0
		begin
			set @CashDataStoreDB = @CashDataStoreDB + '.dbo.CashDataTasks';
			set @insertState = 'INSERT INTO '+ @CashDataStoreDB + ' (task_id,file_creation_time,generation_time,cash_data_file)';
			set @tblCol = 'cash_data_file';
		end
	IF @isTx != 0
		begin
			set @CashDataStoreDB = @CashDataStoreDB + '.dbo.TxDataTasks';
			set @insertState = 'INSERT INTO '+ @CashDataStoreDB + ' (task_id,file_creation_time,generation_time,tx_data_file)';
			set @tblCol = 'tx_data_file';
		end
	IF @StatementType = 'Insert'
	BEGIN
		set @sql = N''+ @insertState + 
		' VALUES (' + Cast(@taskId as varchar(max)) + ', convert(datetime,CONVERT(varchar,''' + Cast(@fileCreationTime as varchar(max)) + ''',121),121), 
		convert(datetime,CONVERT(varchar,''' + Cast(@generationTime as varchar(max)) + ''',121),121),convert(varbinary(max),'''+ Cast(@content as varchar(max)) +'''));'
		Exec(@sql);
		set @sql = N'SELECT task_id from ' + @CashDataStoreDB + ' where task_id = ' + Cast(@taskId as varchar(max))
		Exec(@sql);
	END
	IF @StatementType = 'Update'
	BEGIN
		set @sql = N'UPDATE ' + @CashDataStoreDB +
			' SET generation_time =  convert(datetime,CONVERT(varchar,''' + Cast(@generationTime as varchar(max)) + ''',121),121),'
			+ @tblCol + ' = ' + @tblCol + ' + Convert(varbinary(max),''' + Cast(@content as varchar) + ''')
			  WHERE task_id = ' + Cast(@taskId as varchar(max));
		Exec(@sql);
		select @@ROWCOUNT;
	END
END
GO


