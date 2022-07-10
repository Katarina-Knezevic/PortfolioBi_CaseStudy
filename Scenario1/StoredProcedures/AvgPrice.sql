USE [LokalDB]
GO
/****** Object:  StoredProcedure [dbo].[AvgPrice]    Script Date: 8.7.2022. 09:18:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
ALTER Procedure [dbo].[AvgPrice]
	@ArgCompany nvarchar(255)
as

set nocount on

	DECLARE @AvgPrice float; 
	
	SELECT AVG(Price) AS Price
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany