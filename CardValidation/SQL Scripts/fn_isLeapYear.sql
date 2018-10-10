USE [CardValidation]
GO
/****** Object:  UserDefinedFunction [dbo].[isLeapYear]    Script Date: 10/10/2018 17:10:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[isLeapYear](@year INT)
RETURNS bit
BEGIN
    DECLARE @retVal bit = 0;
	IF (@year % 4 = 0) AND (@year % 100 != 0) OR (@year % 400 = 0)
		SET @retVal = 1
    RETURN @retVal
END
GO