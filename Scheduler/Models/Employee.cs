using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
    /// <summary>
    /// Класс, описывающий произвольного сотрудника.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество (при наличии).
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
