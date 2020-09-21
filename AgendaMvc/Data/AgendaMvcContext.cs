using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgendaMvc.Models;

namespace AgendaMvc.Data
{
    public class AgendaMvcContext : DbContext
    {
        public AgendaMvcContext (DbContextOptions<AgendaMvcContext> options)
            : base(options)
        {
        }

        public DbSet<AgendaMvc.Models.TipoContato> TipoContato { get; set; }
    }
}
