USE [SampleStore]
GO

/****** Object:  Table [dbo].[BillingProduct]    Script Date: 23-02-2020 03:38:15 ******/
DROP TABLE [dbo].[BillingProduct]
GO

/****** Object:  Table [dbo].[BillingProduct]    Script Date: 23-02-2020 03:38:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BillingProduct](
	[BarCode] [varchar](100) NOT NULL,
	[ItemName] [varchar](100) NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
	[Value] [float] NULL,
	[ItemDiscountPercentage] [float] NULL,
	[ItemDiscountAmount] [float] NULL,
	[TaxableValue] [float] NULL,
	[BillingTransactionId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BarCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

