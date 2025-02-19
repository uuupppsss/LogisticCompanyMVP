using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompanyMVP.Model
{
    public class DataBase:DbContext
    {
        private readonly string _filename;

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        //public DataBase(string filename)
        //{
        //    _filename = filename;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Database");
            //Directory.CreateDirectory(sqlitePath);
            //var filename = $"{sqlitePath}\f{_filename}";
            //if (!File.Exists(filename))
            //    File.Create(filename);
            //optionsBuilder.UseSqlite($"Data Source={filename}");
            optionsBuilder.UseSqlite("Data Source=LogisticCompanyMVP.db");
        }

    }
}
