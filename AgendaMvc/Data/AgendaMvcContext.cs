using Microsoft.EntityFrameworkCore;

namespace AgendaMvc.Data
{
    public class AgendaMvcContext : DbContext
    {
        public AgendaMvcContext (DbContextOptions<AgendaMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Models.TipoContato> TipoContato { get; set; }
        public DbSet<Models.Contatos> Contatos{ get; set; }
    }
}
