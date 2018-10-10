using CardValidation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardValidation.Core.Interfaces
{
    public interface ICardValidationRepository
    {
        ValidationResponse ValidateCard(string cardNumber, string cardType, string expiryDate);
        Task AddCard(Card card);
    }
}
