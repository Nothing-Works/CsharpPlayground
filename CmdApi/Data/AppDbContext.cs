using CmdApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CmdApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
        : base(options)
        { }

        public DbSet<Command> Commands { get; set; }
    }
}