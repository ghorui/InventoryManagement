USE [SampleStore]
GO

/****** Object:  Table [dbo].[BVendor]    Script Date: 23-02-2020 03:39:10 ******/
DROP TABLE [dbo].[BVendor]
GO

/****** Object:  Table [dbo].[BVendor]    Script Date: 23-02-2020 03:39:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BVendor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

