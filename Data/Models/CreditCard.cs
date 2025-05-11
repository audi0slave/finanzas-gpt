using System;
using System.Collections.Generic;

namespace FinanceApp.Data.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Bank { get; set; }
        public string Name { get; set; }
        public DateTime ClosingDate { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
