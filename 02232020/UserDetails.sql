USE [SampleStore]
GO

/****** Object:  Table [dbo].[UserDetails]    Script Date: 23-02-2020 03:40:24 ******/
DROP TABLE [dbo].[UserDetails]
GO

/****** Object:  Table [dbo].[UserDetails]    Script Date: 23-02-2020 03:40:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserDetails](
	[UserID] [nvarchar](256) NULL,
	[Name] [varchar](80) NULL,
	[FBLink] [varchar](50) NULL,
	[Address] [nvarchar](1) NULL
) ON [PRIMARY]
GO

