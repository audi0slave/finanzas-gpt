using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceApp.Data.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string Lender { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        // Nueva descripción para diferenciar tipos
        public string Description { get; set; }

        // Relación a pagos que se guardan como transacciones
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

        [NotMapped]
        public string DisplayName => $"{Lender} – {Description}";
    }
}
