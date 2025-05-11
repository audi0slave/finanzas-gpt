using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceApp.Data.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentValue { get; set; }
    }
}
