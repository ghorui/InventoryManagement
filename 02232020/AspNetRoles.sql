USE [SampleStore]
GO

/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 23-02-2020 03:36:29 ******/
DROP TABLE [dbo].[AspNetRoles]
GO

/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 23-02-2020 03:36:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

