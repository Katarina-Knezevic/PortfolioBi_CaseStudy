USE [LokalDB]
GO
/****** Object:  StoredProcedure [dbo].[LocalMaxPrice]    Script Date: 8.7.2022. 09:19:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER Procedure [dbo].[LocalMaxPrice]
	@ArgCompany nvarchar(255)
as

set nocount on

	DECLARE @Count int;
	DECLARE @AvgSubtraction float;


	DECLARE @LocalMaxPrice float; 
	DECLARE @MaxSubtraction float;
	DECLARE @LocalMaxDate nvarchar(255);

	DECLARE @Price1 float;
	DECLARE @Price2 float; 
	DECLARE @Price3 float; 

	DECLARE @Date1 nvarchar(255);
	DECLARE @Date2 nvarchar(255);
	DECLARE @Date3 nvarchar(255);
	
	SET @LocalMaxPrice = 0;
	SET @MaxSubtraction = 0;
	SET @LocalMaxDate = '';


	DECLARE kursor CURSOR LOCAL FOR 
	SELECT [Date], [Price]
	FROM [LokalDB].[dbo].[Data]
	WHERE Company=@ArgCompany ;
	
	
	OPEN kursor

	FETCH NEXT FROM kursor
			INTO @Date1, @Price1;
	
	IF @@FETCH_STATUS = 0 
	BEGIN
	FETCH NEXT FROM kursor
			INTO @Date2, @Price2;
	END

	SET @MaxSubtraction = @Price1 - @Price2;
	SET @Count = 1;


	IF @MaxSubtraction > 0
	BEGIN
		SET @LocalMaxPrice = @Price1;	
			SET @LocalMaxDate = @Date1;	
	SET @AvgSubtraction = @Price1 - @Price2;
	END
	ELSE
	BEGIN
		SET @MaxSubtraction = 0;
		SET @LocalMaxPrice = @Price2;
		SET @LocalMaxDate = @Date2;	
		SET @AvgSubtraction = @Price2 - @Price1;
	END
	
	WHILE @@FETCH_STATUS = 0  
    BEGIN
        FETCH NEXT FROM kursor
			INTO @Date3, @Price3;


		IF @Price2 - @Price3 > @MaxSubtraction 	
		BEGIN
			SET @MaxSubtraction = @Price2 - @Price3;
			SET @AvgSubtraction = @AvgSubtraction + @MaxSubtraction;
			SET @Count = @Count + 1;
			SET @LocalMaxPrice = @Price2
			SET @LocalMaxDate = @Date2;	


		END
	
		SET @Price2 = @Price3;
		SET @Date2 = @Date3;
	
	END

	CLOSE kursor;

	SET @AvgSubtraction = @AvgSubtraction/@Count;
			
	SELECT @LocalMaxDate AS LocalMaxDate, @LocalMaxPrice AS Price, @MaxSubtraction AS MaxSubtraction;
 
	DEALLOCATE kursor;