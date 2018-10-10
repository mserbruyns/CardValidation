using CardValidation.Core.Interfaces;
using CardValidation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CardValidation.Infrastructure
{
    public class CardValidationRepository : ICardValidationRepository
    {
        private readonly CardValidationContext _dbContext;

        public CardValidationRepository(CardValidationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddCard(Card card)
        {
            _dbContext.Cards.Add(card);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            return await _dbContext.Cards.ToListAsync();
        }

        public ValidationResponse ValidateCard(string cardNumber, string cardType, string expiryDate)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                 new SqlParameter
                 {
                     ParameterName = "@cardNumber",
                     DbType = System.Data.DbType.String,
                     Direction = System.Data.ParameterDirection.Input,
                     Value = cardNumber
                 },
                 new SqlParameter
                 {
                    ParameterName = "@cardType",
                    DbType = System.Data.DbType.String,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = cardType
                 },
                 new SqlParameter
                 {
                    ParameterName = "@input_expiry",
                    DbType = System.Data.DbType.String,
                    Direction = System.Data.ParameterDirection.Input,
                    Value = expiryDate
                 }
            };

            var outputParameter = new SqlParameter("@result", DbType.String)
            {
                Direction = ParameterDirection.Output,
                DbType = System.Data.DbType.String,
                Size = 50

            };
            parameters.Add(outputParameter);
            _dbContext.Database.ExecuteSqlCommand("exec ValidateCard @cardNumber, @cardType, @input_expiry, @result OUT", parameters);

            var response = new ValidationResponse()
            {
                CardType = cardType,
                CardStatus = outputParameter.Value.ToString()

            };

            return response;
        }
    }
}
