using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class SqliteDataContext : DataContext
    {
        public SqliteDataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=TheSocialApp.db");
    }
}