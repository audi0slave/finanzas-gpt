using System;
using Microsoft.EntityFrameworkCore;
using FinanceApp.Data.Models;

namespace FinanceApp.Data
{
    public class FinanceContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(Settings.ConnectionString, new MySqlServerVersion(new Version(8, 0, 30)));

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Transaction>()
                 .Property(t => t.Amount)
                 .HasColumnType("decimal(18,2)");
        }
    }
}
