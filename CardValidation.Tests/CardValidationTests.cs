using CardValidation.Controllers;
using CardValidation.Core.Interfaces;
using CardValidation.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CardValidation.Tests
{
    public class CardValidationTests
    {
        [Fact]
        public async Task InvalidVisa()
        {
            // Arrange
            string cardNumber = "4000000000000000";
            string cardType = "VISA";
            string expiryDate = "102023"; //not a leap year

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "INVALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("INVALID", returnValue.CardStatus);
        }

        [Fact]
        public async Task ValidVisa()
        {
            // Arrange
            string cardNumber = "4000000000000000";
            string cardType = "VISA";
            string expiryDate = "102024"; //leap year

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "VALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("VALID", returnValue.CardStatus);
        }

        [Fact]
        public async Task InvalidMasterCard()
        {
            // Arrange
            string cardNumber = "5000000000000000";
            string cardType = "MasterCard";
            string expiryDate = "102026"; //not a prime year

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "INVALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("INVALID", returnValue.CardStatus);
        }

        [Fact]
        public async Task ValidMasterCard()
        {
            // Arrange
            string cardNumber = "5000000000000000";
            string cardType = "MasterCard";
            string expiryDate = "102027"; //prime year

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "VALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("VALID", returnValue.CardStatus);
        }

        [Fact]
        public async Task InvalidAmex()
        {
            // Arrange
            string cardNumber = "3400000000000000"; //too long
            string cardType = "Amex";
            string expiryDate = "102026"; // doesn't matter for Amex

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "INVALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("INVALID", returnValue.CardStatus);
        }

        [Fact]
        public async Task ValidAmex()
        {
            // Arrange
            string cardNumber = "340000000000000"; //15 characters = OK
            string cardType = "Amex";
            string expiryDate = "102027"; // doesn't matter for Amex

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "VALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("VALID", returnValue.CardStatus);
        }

        [Fact]
        public async Task InvalidJCB()
        {
            // Arrange
            string cardNumber = "350000000000000"; //too short
            string cardType = "JCB";
            string expiryDate = "102026"; // doesn't matter for JCB

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "INVALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("INVALID", returnValue.CardStatus);
        }

        [Fact]
        public async Task ValidJCB()
        {
            // Arrange
            string cardNumber = "35000000000000"; //16 characters
            string cardType = "JCB";
            string expiryDate = "102027"; // doesn't matter for JCB

            var mockRepo = new Mock<ICardValidationRepository>();
            mockRepo.Setup(repo => repo.ValidateCard(cardNumber, cardType, expiryDate))
                .Returns(new ValidationResponse() { CardStatus = "VALID", CardType = cardType });
            var controller = new CardsController(mockRepo.Object);

            // Act
            var result = await controller.ValidateCard(cardNumber, expiryDate);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ValidationResponse>(actionResult.Value);
            Assert.Equal("VALID", returnValue.CardStatus);
        }
    }
}
