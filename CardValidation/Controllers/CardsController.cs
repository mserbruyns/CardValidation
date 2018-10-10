using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardValidation.Models;
using System.Data.SqlClient;
using System.Data;
using CardValidation.Logic;
using CardValidation.Infrastructure;
using CardValidation.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using CardValidation.Utils;

namespace CardValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {

        private readonly ICardValidationRepository _cardValidationRepository;

        public CardsController(ICardValidationRepository cardValidationRepository)
        {
            _cardValidationRepository = cardValidationRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        public async Task<IActionResult> GetCards()
        {
            return Ok(await _cardValidationRepository.GetCards());
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> AddCard(string cardNumber, string expiryDate)
        {
            await this._cardValidationRepository.AddCard(new Card() { cardNumber = cardNumber, expiryDate = expiryDate });
            return Ok("Added new card");
        }

        private static readonly Regex rxNonDigits = new Regex(@"[^\d]+");

        [HttpGet("validatecard")]
        [ProducesResponseType(200, Type = typeof(ValidationResponse))]
        public async Task<IActionResult> ValidateCard(string cardNumber, string expiryDate)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return BadRequest("cardNumber can't be empty");

            int n;
            bool isNumeric = int.TryParse("123", out n);
            if (!isNumeric)
                return BadRequest("expiryDate must be a number");
            
            string cleanedCardNumber = RegexUtils.OnlyDigits(cardNumber);
            var cardType = CardValidationLogic.CheckCardType(cleanedCardNumber);
            var response = this._cardValidationRepository.ValidateCard(cleanedCardNumber, cardType, expiryDate);
            return Ok(response);
        }
    }
}