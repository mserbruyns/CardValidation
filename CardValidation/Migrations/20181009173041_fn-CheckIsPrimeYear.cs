﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CardValidation.Migrations
{
    public partial class fnCheckIsPrimeYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fn = @"USE CardValidation
GO
/****** Object:  UserDefinedFunction [dbo].[isPrime]    Script Date: 9/10/2018 17:02:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[isPrime](@number INT)
RETURNS bit
BEGIN
    DECLARE @retVal bit = 1;
    DECLARE @x INT = 1;
    DECLARE @y INT = 0;

    WHILE (@x <= @number )
    BEGIN
            IF (( @number % @x) = 0 )
            BEGIN
                SET @y = @y + 1;
            END

            IF (@y > 2 )
            BEGIN
                SET @retVal = 0
                BREAK
            END

            SET @x = @x + 1
    END
    RETURN @retVal
END";

            migrationBuilder.Sql(fn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
