using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class CurrencySeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, Name = "US Dollar", CurrencyCode = "USD", ShortText = "USD", LongText = "United States Dollar" },
                new Currency { Id = 2, Name = "Euro", CurrencyCode = "EUR", ShortText = "EUR", LongText = "Euro" },
                new Currency { Id = 3, Name = "Japanese Yen", CurrencyCode = "JPY", ShortText = "JPY", LongText = "Japanese Yen" },
                new Currency { Id = 4, Name = "British Pound", CurrencyCode = "GBP", ShortText = "GBP", LongText = "British Pound Sterling" },
                new Currency { Id = 5, Name = "Australian Dollar", CurrencyCode = "AUD", ShortText = "AUD", LongText = "Australian Dollar" },
                new Currency { Id = 6, Name = "Canadian Dollar", CurrencyCode = "CAD", ShortText = "CAD", LongText = "Canadian Dollar" },
                new Currency { Id = 7, Name = "Swiss Franc", CurrencyCode = "CHF", ShortText = "CHF", LongText = "Swiss Franc" },
                new Currency { Id = 8, Name = "Chinese Yuan", CurrencyCode = "CNY", ShortText = "CNY", LongText = "Chinese Yuan Renminbi" },
                new Currency { Id = 9, Name = "Hong Kong Dollar", CurrencyCode = "HKD", ShortText = "HKD", LongText = "Hong Kong Dollar" },
                new Currency { Id = 10, Name = "New Zealand Dollar", CurrencyCode = "NZD", ShortText = "NZD", LongText = "New Zealand Dollar" },
                new Currency { Id = 11, Name = "Swedish Krona", CurrencyCode = "SEK", ShortText = "SEK", LongText = "Swedish Krona" },
                new Currency { Id = 12, Name = "South Korean Won", CurrencyCode = "KRW", ShortText = "KRW", LongText = "South Korean Won" },
                new Currency { Id = 13, Name = "Singapore Dollar", CurrencyCode = "SGD", ShortText = "SGD", LongText = "Singapore Dollar" },
                new Currency { Id = 14, Name = "Norwegian Krone", CurrencyCode = "NOK", ShortText = "NOK", LongText = "Norwegian Krone" },
                new Currency { Id = 15, Name = "Mexican Peso", CurrencyCode = "MXN", ShortText = "MXN", LongText = "Mexican Peso" },
                new Currency { Id = 16, Name = "Indian Rupee", CurrencyCode = "INR", ShortText = "INR", LongText = "Indian Rupee" },
                new Currency { Id = 17, Name = "Brazilian Real", CurrencyCode = "BRL", ShortText = "BRL", LongText = "Brazilian Real" },
                new Currency { Id = 18, Name = "South African Rand", CurrencyCode = "ZAR", ShortText = "ZAR", LongText = "South African Rand" },
                new Currency { Id = 19, Name = "Russian Ruble", CurrencyCode = "RUB", ShortText = "RUB", LongText = "Russian Ruble" },
                new Currency { Id = 20, Name = "Turkish Lira", CurrencyCode = "TRY", ShortText = "TRY", LongText = "Turkish Lira" });
        }
    }
}
