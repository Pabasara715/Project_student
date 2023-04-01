using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS_System
{
    public class DataBaseContext : DbContext
    {

        private readonly string path = @"D:\Campus\Academics\Semester 3\GUI Programming\Project_student\SRS_System_Data.db";
        protected override void OnConfiguring(DbContextOptionsBuilder
               optionsBuilder) => optionsBuilder.UseSqlite($"Data Source ={path}");

        public DbSet<User> User { get; set; }
    }
}
