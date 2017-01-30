USE [PracticalTest]
GO

/****** Object:  Table [dbo].[Box]    Script Date: 2016-06-22 09:03:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Begin Transaction
If Not Exists (Select * from SysoBjects where name = 'Box')
CREATE TABLE [dbo].[Box](
	[BoxId] [int] IDENTITY(1,1) NOT NULL,
	[BoxType] [int] NOT NULL,
	[Radius] [int]  NULL,
	[Width] [int]  NULL,
	[Height] [int]  NULL,
	[Area] [float] NOT NULL
) ON [PRIMARY]
Else
       Print 'Box Already Exists'
GO
Commit
Go



