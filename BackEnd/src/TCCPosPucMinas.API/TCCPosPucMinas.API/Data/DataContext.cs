using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.API.Models;

namespace TCCPosPucMinas.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
