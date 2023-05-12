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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        //    modelBuilder.Entity<Veiculo>(entity =>
        //    {
        //        entity.HasOne(m => m.MarcaId)
        //            .WithMany(p => p.)
        //            .HasForeignKey(d => d.IdCliente)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_NotaFiscalxCliente");                
        //    });
        //}
    }
}
