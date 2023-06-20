using TCCPosPucMinas.Application.Dtos;
using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Application.Interface
{
    public interface IMarcaService
    {
        Task<MarcaDto?> AddMarca(MarcaDto model);
        Task<MarcaDto?> UpdateMarca(int marcaId, MarcaDto model);
        Task<bool> DeleteMarca(int marcaId);

        Task<MarcaDto[]> GetAllMarcasAsync();
        Task<MarcaDto?> GetMarcaByIdAsync(int marcaId);
        Task<MarcaDto?> GetMarcaByNomeAsync(string marca);
    }
}
