using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Leverx.Models;

namespace Leverx.Data
{
    public class LeverxContextDb : DbContext
    {
        public LeverxContextDb (DbContextOptions<LeverxContextDb> options)
            : base(options)
        {
        }

        public DbSet<Leverx.Models.Mentee> Mentee { get; set; }
        public DbSet<Leverx.Models.Level> Level { get; set; }
    }
}
