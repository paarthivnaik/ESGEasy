using ESG.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.DataBaseSeeder
{
    public static class LanguageSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "English", IsoCode = "en" },
                new Language { Id = 2, Name = "Dutch", IsoCode = "nl" },
                new Language { Id = 3, Name = "Spanish", IsoCode="es"},
                new Language { Id = 4, Name = "French", IsoCode = "fr" },
                new Language { Id = 5, Name = "German", IsoCode = "de" }
                );
        }
    }
}
