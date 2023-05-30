using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Persistence.Repositoty
{
    public class VeiculoPersistence : GeralPersistence, IVeiculoPersist
    {     
        public VeiculoPersistence(TCCPosPucMinasContext context) : base(context)
        {
            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region Veiculo

        public async Task<Veiculo[]> GetAllVeiculosAsync()
        {
            IQueryable<Veiculo> query = _context.Veiculos.Include(v => v.Marca);
            query = query.OrderBy(v => v.Marca != null ? v.Marca.Nome : v.Descricao).OrderBy(v => v.Descricao);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Veiculo[]> GetAllVeiculosByMarcaAsync(string marca)
        {
            IQueryable<Veiculo> query = _context.Veiculos.Include(v => v.Marca);
            query = query.Where(v => v.Marca != null && v.Marca.Nome.ToLower().Equals(marca.ToLower()));

            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Veiculo?> GetVeiculoByIdAsync(int veiculoId)
        {
            return await _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Id == veiculoId);
        }

        #endregion
    }
}
