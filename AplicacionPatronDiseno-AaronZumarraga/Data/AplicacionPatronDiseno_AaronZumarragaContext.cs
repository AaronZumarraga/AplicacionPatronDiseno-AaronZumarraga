using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicacionPatronDiseno_AaronZumarraga.Models;

namespace AplicacionPatronDiseno_AaronZumarraga.Data
{
    public class AplicacionPatronDiseno_AaronZumarragaContext : DbContext
    {
        public AplicacionPatronDiseno_AaronZumarragaContext (DbContextOptions<AplicacionPatronDiseno_AaronZumarragaContext> options)
            : base(options)
        {
        }

        public DbSet<AplicacionPatronDiseno_AaronZumarraga.Models.Bridge> Bridge { get; set; } = default!;
    }
}
