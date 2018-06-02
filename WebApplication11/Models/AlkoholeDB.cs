using System.Data.Entity;

namespace WebApplication11.Models
{
    public class AlkoholeDB : DbContext
    {
        public DbSet<Whisky> Whisky { get; set; }

        public DbSet<Wino> Wina { get; set; }
    }
}