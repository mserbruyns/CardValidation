using Microsoft.EntityFrameworkCore.Migrations;

namespace CardValidation.Migrations
{
    public partial class fnValidateCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fn = @"USE CardValidation

go

IF Object_id(N'dbo.Getcardinformation', N'TF') IS NOT NULL
  DROP FUNCTION dbo.getcardinformation

go

CREATE FUNCTION dbo.Getcardinformation(@input_card   NVARCHAR(20),
                                       @input_expiry NVARCHAR(6))
returns @cardInformation TABLE (
  cardnumber NVARCHAR(50) NULL,
  cardtype   NVARCHAR(50) NULL,
  result     NVARCHAR(50) NULL )
AS
  BEGIN
      DECLARE @cardType     NVARCHAR(50),
              @result       NVARCHAR(50),
              @expiry_month NVARCHAR(2),
              @expiry_year  NVARCHAR(4)

      SET @result = 'INVALID'
      SET @cardType = CASE
                        WHEN @input_card LIKE '4%' THEN 'VISA'
                        WHEN @input_card LIKE '5%' THEN 'MasterCard'
                        WHEN @input_card LIKE '34%'
                              OR @input_card LIKE '37%' THEN 'Amex'
                        WHEN @input_card LIKE '35%' THEN 'JCB'
                        ELSE 'Unknown'
                      END

      IF @cardType = 'Amex'
        BEGIN
            IF Len(@input_card) = 15
              SET @result = 'VALID' --AMEX = VALID
        END
      ELSE
        BEGIN
            IF Len(@input_card) = 16 -- it should be 16
              BEGIN
                  IF @cardType = 'JCB'
                    BEGIN
                        SET @result = 'VALID' --JCB = VALID
                    END
                  ELSE
                    BEGIN
                        --check valid year
                        IF Isnumeric(@input_expiry) = 1
                          BEGIN
                              SET @expiry_month = Substring(@input_expiry, 1, 2)
                              SET @expiry_year = Substring(@input_expiry, 3, 4)

                              --check is valid year
                              IF Isdate(@expiry_year) = 1
                                BEGIN
                                    IF @cardType = 'VISA'
                                      BEGIN
                                          --check if LEAP YEAR
                                          DECLARE @isLeapYear BIT

                                          SELECT @isLeapYear =
                                                 dbo.Isleapyear(@expiry_year)

                                          IF @isLeapYear = 1
                                            SET @result = 'VALID'
                                      END

                                    IF @cardType = 'MasterCard'
                                      BEGIN
                                          DECLARE @isPrime BIT

                                          SELECT @isPrime =
                                                 dbo.Isprime(@expiry_year)

                                          IF @isPrime = 1
                                            SET @result = 'VALID'
                                      --MasterCard = VALID
                                      END
                                END
                          END
                    END
              END
        END

      --check if card exists
      DECLARE @foundCard NVARCHAR(50)

      SELECT TOP 1 @foundCard = cardnumber
      FROM   cards
      WHERE  cardnumber = @input_card

      IF @foundCard IS NULL
        BEGIN
            SET @result = 'Does not exist'
        END

      SET @foundCard = @input_card

      BEGIN
          INSERT @cardInformation
          SELECT @foundCard,
                 @cardType,
                 @result
      END

      RETURN
  END

go ";

            migrationBuilder.Sql(fn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
