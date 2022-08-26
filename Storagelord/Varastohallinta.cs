using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Storagelord
{
    public class Varastohallinta : DbContext
    {
        public DbSet<Tuote>? tuotteet { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Pelitietokanta;" +
                "User Id=sa;" +
                "Password=Lasi1423#3;";
            optionsBuilder.UseSqlServer(connection);

            //"Integrated Security=true;" + 
            //"MultipleActiveResultSets=true;";
        }
    }
}
