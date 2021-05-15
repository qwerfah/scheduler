using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scheduler.Models;
using System;

namespace Scheduler.Contexts.Configurations
{
    /// <summary>
    /// Класс конфигурации таблицы сотрудников в БД.
    /// </summary>
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Employees");

            builder.Property(em => em.Name).IsRequired();
            builder.Property(em => em.Surname).IsRequired();
            builder.Property(em => em.BirthDate).IsRequired();
        }
    }
}
