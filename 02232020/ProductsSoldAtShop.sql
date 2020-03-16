USE [SampleStore]
GO

/****** Object:  Table [dbo].[ProductsSoldAtShop]    Script Date: 23-02-2020 03:40:06 ******/
DROP TABLE [dbo].[ProductsSoldAtShop]
GO

/****** Object:  Table [dbo].[ProductsSoldAtShop]    Script Date: 23-02-2020 03:40:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductsSoldAtShop](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BarCode] [varchar](50) NOT NULL,
	[ItemName] [varchar](80) NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
	[Value] [float] NULL,
	[ItemDiscountPercentage] [float] NULL,
	[ItemDiscountAmount] [float] NULL,
	[TaxableValue] [float] NULL,
	[BillingTrxId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

