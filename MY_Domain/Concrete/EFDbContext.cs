using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MY_Domain.Entities;

namespace MY_Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Informs> Informs { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<ResearchNews> ResearchNews { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<AllIntroduce> AllIntroduce { get; set; }
        public DbSet<UsefulLinks> UsefulLinks { get; set; }
    }
}
