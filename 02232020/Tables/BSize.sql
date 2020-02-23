USE [SampleStore]
GO

/****** Object:  Table [dbo].[BSize]    Script Date: 23-02-2020 03:38:55 ******/
DROP TABLE [dbo].[BSize]
GO

/****** Object:  Table [dbo].[BSize]    Script Date: 23-02-2020 03:38:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

