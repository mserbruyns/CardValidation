using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CardValidation.Models
{
    public class CardValidationContext: DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public CardValidationContext(DbContextOptions<CardValidationContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CardValidationContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card() { id = 1, cardNumber = "4000000000000000", expiryDate = new DateTime(2004, 12, 5) },
                new Card() { id = 2, cardNumber = "5000000000000000", expiryDate = new DateTime(2004, 12, 5) },
                new Card() { id = 3, cardNumber = "35000000000000000", expiryDate = new DateTime(2004, 12, 5) },
                new Card() { id = 4, cardNumber = "4000000000000000", expiryDate = new DateTime(2004, 12, 5) }
            );
        }
    }
}
