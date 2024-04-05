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
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                .HasOne<Account>()
                .WithOne()
                .HasForeignKey("account_id")
                .OnDelete(DeleteBehavior.Cascade);

                entity.ToTable("user");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity
                .HasOne<User>()
                .WithOne()
                .HasForeignKey("user_id")
                .OnDelete(DeleteBehavior.Cascade);

                entity.ToTable("person");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_type");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity
                .HasOne<TransactionType>()
                .WithMany()
                .HasForeignKey("transaction_type_id")
                .OnDelete(DeleteBehavior.Cascade);

                entity
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey("account_sender")
                .OnDelete(DeleteBehavior.Cascade);

                entity
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey("account_receiver")
                .OnDelete(DeleteBehavior.Cascade);

                entity.ToTable("transactions");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}