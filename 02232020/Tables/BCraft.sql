USE [SampleStore]
GO

/****** Object:  Table [dbo].[BCraft]    Script Date: 23-02-2020 03:37:35 ******/
DROP TABLE [dbo].[BCraft]
GO

/****** Object:  Table [dbo].[BCraft]    Script Date: 23-02-2020 03:37:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BCraft](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

