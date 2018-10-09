using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardValidation.Logic
{
    public static class CardValidationLogic
    {
        public static string CheckCardType(string card)
        {
            string type = "Unknown";

            if (card.StartsWith("4"))
            {
                type = "VISA";
            }else if (card.StartsWith("5"))
            {
                type = "MasterCard";
            }
            else if (card.StartsWith("34") || card.StartsWith("37"))
            {
                type = "Amex";
            }
            else if (card.StartsWith("37"))
            {
                type = "JCB";
            }

            return type;
        }
    }
}
