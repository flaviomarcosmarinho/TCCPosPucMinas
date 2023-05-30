using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Persistence.Repositoty
{
    public class MarcaPersistence : GeralPersistence, IMarcaPersist
    {
        public MarcaPersistence(TCCPosPucMinasContext context) : base(context)
        {
            //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }        

        #region Marca

        public async Task<Marca[]> GetAllMarcasAsync()
        {
            IQueryable<Marca> query = _context.Marcas.Include(m => m.Veiculos);
            query = query.OrderBy(m => m.Nome);

            return await query.AsNoTracking().OrderBy(m => m.Nome).ToArrayAsync();
        }

        public async Task<Marca?> GetMarcaByIdAsync(int marcaId)
        {
            return await _context.Marcas.AsNoTracking().FirstOrDefaultAsync(m => m.Id == marcaId);
        }

        public async Task<Marca?> GetMarcaByNomeAsync(string marca)
        {
            return await _context.Marcas.AsNoTracking().FirstOrDefaultAsync(m => m.Nome.ToLower().Equals(marca.ToLower()));
        }

        #endregion       
    }
}
