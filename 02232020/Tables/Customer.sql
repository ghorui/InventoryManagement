USE [SampleStore]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 23-02-2020 03:39:27 ******/
DROP TABLE [dbo].[Customer]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 23-02-2020 03:39:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MobNum] [varchar](20) NULL,
	[Name] [varchar](80) NULL,
	[Address] [varchar](200) NULL,
	[Email] [varchar](50) NULL,
	[Isdeleted] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

