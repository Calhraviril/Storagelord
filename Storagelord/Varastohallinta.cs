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
                "Initial Catalog=Varastohallinta;" +
                "User Id=sa;" +
                "Password=salasana;"; // Varmaan pitää sun muuttaa tätä 
            optionsBuilder.UseSqlServer(connection);

            //"Integrated Security=true;" + 
            //"MultipleActiveResultSets=true;";
        }
    }
}
