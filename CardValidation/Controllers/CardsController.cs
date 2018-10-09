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

namespace CardValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly CardValidationContext _context;

        public CardsController(CardValidationContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public IEnumerable<Card> GetAllCards()
        {
            return _context.Cards;
        }


        [HttpGet("validatecard")]
        public IEnumerable<Card> ValidateCard(string cardNumber, string expiryDate)
        {

            return _context.Cards;
        }

    }
}