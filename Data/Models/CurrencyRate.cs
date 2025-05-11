using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceApp.Data.Models
{
    public class CurrencyRate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UsdToArs { get; set; }
    }
}
