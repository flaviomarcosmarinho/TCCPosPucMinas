using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Persistence.Interface
{
    public interface IMarcaPersist : IPersist
    {    
        Task<Marca[]> GetAllMarcasAsync();
        Task<Marca?> GetMarcaByIdAsync(int marcaId);
        Task<Marca?> GetMarcaByNomeAsync(string marca);  
    }
}
