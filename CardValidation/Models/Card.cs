using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardValidation.Models
{
    public class Card
    {
        public int id { get; set; }
        public string cardNumber { get; set; }
        public string expiryDate { get; set; }

    }
}
