USE [SampleStore]
GO

/****** Object:  Table [dbo].[BillingDetails]    Script Date: 23-02-2020 03:38:03 ******/
DROP TABLE [dbo].[BillingDetails]
GO

/****** Object:  Table [dbo].[BillingDetails]    Script Date: 23-02-2020 03:38:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BillingDetails](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[TotalAmount] [float] NULL,
	[OverallDiscountRate] [float] NULL,
	[OverallDiscountAmount] [float] NULL,
	[CGSTRate] [float] NULL,
	[CGSTAmount] [float] NULL,
	[SGSTRate] [float] NULL,
	[SGSTAmount] [float] NULL,
	[IGSTRate] [float] NULL,
	[IGSTAmount] [float] NULL,
	[AdditionalCharges] [int] NULL,
	[GrandTotal] [float] NULL,
	[LastUpdateTime] [datetime] NULL,
	[LastUpdatedUser] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

