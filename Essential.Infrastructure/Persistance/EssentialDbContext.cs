using Essential.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential.Infrastructure.Persistance
{
    public class EssentialDbContext : DbContext
    {

        public EssentialDbContext(DbContextOptions<EssentialDbContext> options):base(options)
        {
            
        }


        public DbSet<EssentialModels> Essential { get; set; }



    }
}
