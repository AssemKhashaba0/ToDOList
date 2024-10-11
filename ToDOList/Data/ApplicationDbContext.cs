using Microsoft.EntityFrameworkCore;
using ToDOList.Models;

namespace ToDOList.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<ToDoListEf>ToDoListEfs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build()
               .GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(builder);
        }
    }
}
