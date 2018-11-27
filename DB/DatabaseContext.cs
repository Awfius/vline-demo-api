using Microsoft.EntityFrameworkCore;
using VLine.API.Models;

namespace VLine.API.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Timetable> Timetables { get; set; }
    }
}
