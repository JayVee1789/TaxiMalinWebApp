using Microsoft.EntityFrameworkCore;
using TaxiMalinWebApp.Models;

namespace TaxiMalinWebApp.Data
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Reservation> reservations { get; set; }
    }
}
