using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceApp.Data.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
