using Microsoft.EntityFrameworkCore;
using SimpleBank.Models;

namespace SimpleBank.Data
{
    public class SimpleBankDBContext : DbContext
    {
        public SimpleBankDBContext(DbContextOptions<SimpleBankDBContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(AccountEntity =>
            {
                // To Do
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}