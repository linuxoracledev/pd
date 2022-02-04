using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.DbConTexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }

    }
}
