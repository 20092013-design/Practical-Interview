using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertCurrencyApi.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string CurrencyName { get; set; }
    }
}
