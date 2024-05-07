using CodingTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingTask.DataCon
{
    public class LogNumberDbContext : DbContext
    {
        public LogNumberDbContext(DbContextOptions<LogNumberDbContext> options) : base(options)
        {
        }
        public DbSet<LogNumberModel> LogNumberEntries { get; set; }   //create table in database with name LogNumberEntries
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-6GL5JQD\\SQLEXPRESS;Database=TestNumbers;Integrated Security=True;Trusted_Connection=True;Encrypt=False;");
        }

    }
}
