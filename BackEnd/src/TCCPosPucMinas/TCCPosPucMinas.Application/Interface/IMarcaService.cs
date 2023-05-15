using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Application.Interface
{
    public interface IMarcaService
    {
        Task<Marca?> AddMarca(Marca model);
        Task<Marca?> UpdateMarca(int marcaId, Marca model);
        Task<bool> DeleteMarca(int marcaId);

        Task<Marca[]> GetAllMarcasAsync();
        Task<Marca?> GetMarcaByIdAsync(int marcaId);
        Task<Marca?> GetMarcaByNomeAsync(string marca);
    }
}
