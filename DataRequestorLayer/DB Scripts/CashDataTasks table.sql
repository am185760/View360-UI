USE [cashdatastore_2023]
GO

/****** Object:  Table [dbo].[CashDataTasks]    Script Date: 2/9/2023 10:45:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CashDataTasks](
	[task_id] [int] NOT NULL,
	[file_creation_time] [datetime] NULL,
	[generation_time] [datetime] NULL,
	[cash_data_file] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[task_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


