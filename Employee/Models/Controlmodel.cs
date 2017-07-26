using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("CatData")
        {
            ///
        }

        /// <summary>
        /// Для работы с работниками
        /// </summary>
        public DbSet<Worker> Workers { get; set; }
        /// <summary>
        /// Для работы с подразделениями
        /// </summary>
        public DbSet<Division> Divisions { get; set; }
    }
}