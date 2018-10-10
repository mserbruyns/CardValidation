﻿// <auto-generated />
using System;
using CardValidation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CardValidation.Migrations
{
    [DbContext(typeof(CardValidationContext))]
    [Migration("20181009172921_fn-CheckIsLeapYear")]
    partial class fnCheckIsLeapYear
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CardValidation.Models.Card", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cardNumber");

                    b.Property<DateTime>("expiryDate");

                    b.HasKey("id");

                    b.ToTable("Cards");

                    b.HasData(
                        new { id = 1, cardNumber = "4000000000000000", expiryDate = new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { id = 2, cardNumber = "5000000000000000", expiryDate = new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { id = 3, cardNumber = "35000000000000000", expiryDate = new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { id = 4, cardNumber = "4000000000000000", expiryDate = new DateTime(2004, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
