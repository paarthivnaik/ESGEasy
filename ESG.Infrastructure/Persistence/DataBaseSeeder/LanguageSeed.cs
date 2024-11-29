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
                new Language { Id = 2, Name = "Duch", IsoCode = "nl" });
        }
    }
}
