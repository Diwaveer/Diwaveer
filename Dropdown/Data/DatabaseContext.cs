using Dropdown.Models;
using Microsoft.EntityFrameworkCore;

namespace Dropdown.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }

    }
}
