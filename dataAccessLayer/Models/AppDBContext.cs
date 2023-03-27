using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataAccessLayer.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> dbContext):base(dbContext)
        {
            
        }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Cuisine> Cuisine { get; set;}
    }
}
