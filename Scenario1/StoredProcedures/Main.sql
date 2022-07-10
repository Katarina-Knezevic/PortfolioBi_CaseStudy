USE [LokalDB]
GO
/****** Object:  StoredProcedure [dbo].[Main]    Script Date: 8.7.2022. 09:19:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER Procedure [dbo].[Main]


as

set nocount on


EXEC AvgPrice @ArgCompany = 'Corning, Inc. (GLW US)'
EXEC AvgPrice @ArgCompany = 'GrubHub, Inc. (GRUB US)'


EXEC LocalMaxPrice @ArgCompany = 'Corning, Inc. (GLW US)'
EXEC LocalMaxPrice @ArgCompany = 'GrubHub, Inc. (GRUB US)'

EXEC MaxPrice @ArgCompany = 'Corning, Inc. (GLW US)'
EXEC MaxPrice @ArgCompany = 'GrubHub, Inc. (GRUB US)'


EXEC MinPrice @ArgCompany = 'Corning, Inc. (GLW US)'
EXEC MinPrice @ArgCompany = 'GrubHub, Inc. (GRUB US)'