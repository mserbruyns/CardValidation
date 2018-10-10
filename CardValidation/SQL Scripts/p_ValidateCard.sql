USE [CardValidation]
GO
/****** Object:  StoredProcedure [dbo].[GetcardinformationTest]    Script Date: 10/10/2018 16:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ValidateCard]
@cardNumber NVARCHAR(20) = NULL,
@cardType NVARCHAR(20) = NULL,
@input_expiry NVARCHAR(6) = NULL,
@result NVARCHAR(20) = NULL OUTPUT
AS
  BEGIN
  SET @result = 'INVALID'
      IF @cardType = 'Amex'
        BEGIN
            IF Len(@cardNumber) = 15
              SET @result = 'VALID' --AMEX = VALID
        END
      ELSE
        BEGIN
            IF Len(@cardNumber) = 16 -- it should be 16
              BEGIN
                  IF @cardType = 'JCB'
                    BEGIN
                        SET @result = 'VALID' --JCB = VALID
                    END
                  ELSE
                    BEGIN
                        --check valid year
						 DECLARE @expiry_month NVARCHAR(2), @expiry_year  NVARCHAR(4)
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
                                          SELECT @isLeapYear = dbo.Isleapyear(@expiry_year)
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
      DECLARE @foundCard TINYINT

      SELECT TOP 1 @foundCard = count(*)
      FROM   cards
      WHERE  cardnumber = @cardNumber

      IF @foundCard = 0
        BEGIN
            SET @result = 'Does not exist'
        END

      RETURN
  END

  GO

