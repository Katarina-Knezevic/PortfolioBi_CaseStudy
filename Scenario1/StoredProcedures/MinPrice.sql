USE [LokalDB]
GO
/****** Object:  StoredProcedure [dbo].[MinPrice]    Script Date: 8.7.2022. 09:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER Procedure [dbo].[MinPrice]
	@ArgCompany nvarchar(255)
as

set nocount on

	DECLARE @MinPrice float; 
	
	SELECT @MinPrice = MIN(Price)
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany

	SELECT Company, Security, Date, Price AS Price
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany AND Price = @MinPrice;