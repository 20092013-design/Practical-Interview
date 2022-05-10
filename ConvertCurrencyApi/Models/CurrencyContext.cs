using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertCurrencyApi.Models
{
    public class CurrencyContext:DbContext
    {
        public CurrencyContext(DbContextOptions<CurrencyContext>options):base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }
    }
}
