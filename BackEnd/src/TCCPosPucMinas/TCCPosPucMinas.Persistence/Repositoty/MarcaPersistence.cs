using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Persistence.Repositoty
{
    public class MarcaPersistence : GeralPersistence, IMarcaPersist
    {
        public MarcaPersistence(TCCPosPucMinasContext context) : base(context)
        {            
        }        

        #region Marca

        public async Task<Marca[]> GetAllMarcasAsync()
        {
            IQueryable<Marca> query = _context.Marcas;
            query = query.OrderBy(m => m.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Marca?> GetMarcaByIdAsync(int marcaId)
        {
            return await _context.Marcas.FirstOrDefaultAsync(m => m.Id == marcaId);
        }

        public async Task<Marca?> GetMarcaByNomeAsync(string marca)
        {
            return await _context.Marcas.FirstOrDefaultAsync(m => m.Nome.ToLower().Equals(marca.ToLower()));
        }

        #endregion       
    }
}
