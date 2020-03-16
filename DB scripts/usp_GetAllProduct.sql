USE [SampleStore]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetAllProduct]    Script Date: 08-01-2020 12:58:23 ******/
DROP PROCEDURE [dbo].[usp_GetAllProduct]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetAllProduct]    Script Date: 08-01-2020 12:58:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetAllProduct]
AS
BEGIN
    SET NOCOUNT ON

	SELECT
        *
    FROM Product
END
GO


