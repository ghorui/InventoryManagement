USE [SampleStore]
GO

/****** Object:  Table [dbo].[ProductsAtShop]    Script Date: 23-02-2020 03:39:49 ******/
DROP TABLE [dbo].[ProductsAtShop]
GO

/****** Object:  Table [dbo].[ProductsAtShop]    Script Date: 23-02-2020 03:39:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductsAtShop](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BarCode] [varchar](50) NOT NULL,
	[ItemName] [varchar](80) NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
	[Value] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

