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
            /* User to Account Relationship */
            modelBuilder.Entity<Account>()
                .HasOne(account => account.User)
                .WithOne(user => user.Account)
                .HasForeignKey<User>(user => user.accountId)
                .IsRequired();

            /* Person to User Relationship */
            modelBuilder.Entity<User>()
                .HasOne(user => user.Person)
                .WithOne(person => person.User)
                .HasForeignKey<Person>(person => person.userId)
                .IsRequired();

            /* Account (sender) to Transaction Relationship */
            modelBuilder.Entity<Account>()
                .HasMany(account => account.TransactionsSent)
                .WithOne(transaction => transaction.SenderAccount)
                .HasForeignKey(transaction => transaction.accountSender)
                .IsRequired();

            /* Account (receiver) to Transaction Relationship */
            modelBuilder.Entity<Account>()
                .HasMany(account => account.TransactionsReceived)
                .WithOne(transaction => transaction.ReceiverAccount)
                .HasForeignKey(transaction => transaction.accountReceiver)
                .IsRequired();

            /* Transaction to TransactionType Relationship */
            modelBuilder.Entity<TransactionType>()
                .HasMany(transactionType => transactionType.Transactions)
                .WithOne(transaction => transaction.TransactionType)
                .HasForeignKey(transaction => transaction.transactionTypeId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}