using Microsoft.EntityFrameworkCore;
using Scheduler.Contexts.Configurations;
using Scheduler.Models;
using System;
using System.Configuration;

namespace Scheduler.Contexts
{
    /// <summary>
    /// Контекст данных для соединения с БД с помощью Entity Framework.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Поле контекста для работы с данными таблицы сотрудников в БД.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            var str = ConfigurationManager.ConnectionStrings["DefaultConnection"];

            optionsBuilder.UseNpgsql(str.ConnectionString);
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new EmployeesConfiguration());
        }
    }
}
