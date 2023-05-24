using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Persistence
{
    public class TCCPosPucMinasContext : DbContext
    {
        public TCCPosPucMinasContext(DbContextOptions<TCCPosPucMinasContext> options) : base(options)
        {

        }

        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }        
    }
}
