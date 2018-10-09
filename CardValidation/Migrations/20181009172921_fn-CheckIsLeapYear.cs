using Microsoft.EntityFrameworkCore.Migrations;

namespace CardValidation.Migrations
{
    public partial class fnCheckIsLeapYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fn = @"USE CardValidation
GO
/****** Object:  UserDefinedFunction [dbo].[isLeapYear]    Script Date: 9/10/2018 17:01:57 ******/
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
END";

            migrationBuilder.Sql(fn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
