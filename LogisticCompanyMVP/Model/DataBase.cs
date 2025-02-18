using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompanyMVP.Model
{
    public class DataBase
    {
        private readonly string _filename;

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public DataBase(string filename)
        {
            _filename = filename;
        }


    }
}
