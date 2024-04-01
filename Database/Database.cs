using Microsoft.EntityFrameworkCore;
using SimpleBank.Models;

namespace SimpleBank.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons {  get; set; }
    }
}