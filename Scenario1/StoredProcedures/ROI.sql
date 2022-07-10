USE [LokalDB]
GO
/****** Object:  StoredProcedure [dbo].[ROI]    Script Date: 8.7.2022. 09:20:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER Procedure [dbo].[ROI]

	@ArgCompany nvarchar(255),
	@EndDate nvarChar(225)

as

set nocount on

--ROI Formula: = [(Ending Value / Beginning Value) ^ (1 / num of Years)] – 1
	DECLARE @ROI float; 
	DECLARE @StartPrice float; 
	DECLARE @EndPrice float; 
	DECLARE @StartDate nvarchar(255);
 
	SET @StartDate = 'Jan 02, 2015'
	
	SELECT @EndPrice = Price 
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany AND Date = @EndDate;

	SELECT @StartPrice = Price
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany AND Date = @StartDate;

	SET @ROI = POWER(@EndPrice / @StartPrice, 2)-1;
	SELECT @ROI AS ROI;