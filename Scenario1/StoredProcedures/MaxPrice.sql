USE [LokalDB]
GO
/****** Object:  StoredProcedure [dbo].[MaxPrice]    Script Date: 8.7.2022. 09:20:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER Procedure [dbo].[MaxPrice]
	@ArgCompany nvarchar(255)
as

set nocount on

	DECLARE @MaxPrice float; 
	DECLARE @MaxDate nvarchar(255);
	
	SELECT @MaxPrice = MAX(Price)
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany

	SELECT Company, Security, Date, Price AS Price
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany AND Price = @MaxPrice;