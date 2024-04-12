using Microsoft.EntityFrameworkCore;
using SimpleBank.Models;
using System.Reflection.Emit;

namespace SimpleBank.Data
{
    public class SimpleBankDBContext : DbContext
    {
        public SimpleBankDBContext(DbContextOptions<SimpleBankDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<TransactionType> TransactionTypes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=simpleBank;Username=postgres;Password=CYvr9tNwEbalWAZPsMiC");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountId).HasName("pk_account");

                entity.ToTable("account");

                entity.HasIndex(e => e.Number, "account_number_key").IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.Agency)
                    .HasMaxLength(10)
                    .HasColumnName("agency");
                entity.Property(e => e.Balance)
                    .HasPrecision(16, 2)
                    .HasDefaultValueSql("0.00")
                    .HasColumnName("balance");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("now()")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.Number)
                    .HasMaxLength(14)
                    .HasColumnName("number");
                entity.Property(e => e.StartingCapital)
                    .HasPrecision(16, 2)
                    .HasDefaultValueSql("0.00")
                    .HasColumnName("starting_capital");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("now()")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonId).HasName("pk_person");

                entity.ToTable("person");

                entity.HasIndex(e => e.TaxId, "person_tax_id_key").IsUnique();

                entity.HasIndex(e => e.UserId, "person_user_id_key").IsUnique();

                entity.Property(e => e.PersonId).HasColumnName("person_id");
                entity.Property(e => e.Birthday).HasColumnName("birthday");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("now()")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.LastName)
                    .HasMaxLength(70)
                    .HasColumnName("last_name");
                entity.Property(e => e.Name)
                    .HasMaxLength(70)
                    .HasColumnName("name");
                entity.Property(e => e.TaxId)
                    .HasMaxLength(14)
                    .HasColumnName("tax_id");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("now()")
                    .HasColumnName("updated_at");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User).WithOne(p => p.Person)
                    .HasForeignKey<Person>(d => d.UserId)
                    .HasConstraintName("fk_user_person");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId).HasName("pk_transaction");

                entity.ToTable("transactions");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
                entity.Property(e => e.AccountReceiver).HasColumnName("account_receiver");
                entity.Property(e => e.AccountSender).HasColumnName("account_sender");
                entity.Property(e => e.DateTransaction)
                    .HasDefaultValueSql("now()")
                    .HasColumnName("date_transaction");
                entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");
                entity.Property(e => e.TransactionValue)
                    .HasPrecision(16, 2)
                    .HasColumnName("transaction_value");

                entity.HasOne(d => d.AccountReceiverNavigation).WithMany(p => p.TransactionAccountReceiverNavigations)
                    .HasForeignKey(d => d.AccountReceiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_receiver_transactions");

                entity.HasOne(d => d.AccountSenderNavigation).WithMany(p => p.TransactionAccountSenderNavigations)
                    .HasForeignKey(d => d.AccountSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_sender_transactions");

                entity.HasOne(d => d.TransactionType).WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transaction_type_transactions");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeId).HasName("pk_transaction_type");

                entity.ToTable("transaction_types");

                entity.HasIndex(e => e.TransactionTypeName, "transaction_types_transaction_type_name_key").IsUnique();

                entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");
                entity.Property(e => e.TransactionTypeName)
                    .HasMaxLength(20)
                    .HasColumnName("transaction_type_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("pk_user");

                entity.ToTable("user");

                entity.HasIndex(e => e.AccountId, "user_account_id_key").IsUnique();

                entity.HasIndex(e => e.Email, "user_email_key").IsUnique();

                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.AccountId).HasColumnName("account_id");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("now()")
                    .HasColumnName("created_at");
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Password).HasColumnName("password");
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql("now()")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Account).WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.AccountId)
                    .HasConstraintName("fk_account_user");
            });
            
            base.OnModelCreating(modelBuilder);
        }

    }
}