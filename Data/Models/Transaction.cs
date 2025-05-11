using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceApp.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        // Nueva propiedad
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int? LoanId { get; set; }
        public Loan Loan { get; set; }
        public int? CurrencyRateId { get; set; }
        public CurrencyRate CurrencyRate { get; set; }

        public int? InstallmentTotal { get; set; }    // total de cuotas
        public int? InstallmentPaid { get; set; }    // cuántas voy pagando

    }
}
