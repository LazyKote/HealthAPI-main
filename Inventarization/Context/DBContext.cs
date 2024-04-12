using HealthAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace HealthAPI.Context
{
    public class DBContext : DbContext
    {

        /*Перечисление моделей*/
        public DbSet<EFStorage> Storages { get; set; }
        public DbSet<EFProduct> Products { get; set; }
        public DBContext(string cnnString)
        {
            ConnectionString = cnnString;
            
            Database.EnsureCreated();
        }

        public string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            /*Если используете другие БД*/
            /*optionsBuilder.UseNpgsql(ConnectionString);
            optionsBuilder.UseMySQL(ConnectionString);*/
        }
    }
}
