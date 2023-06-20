using TCCPosPucMinas.Application.Dtos;

namespace TCCPosPucMinas.Application.Interface
{
    public interface IVeiculoService
    {
        Task<VeiculoDto?> AddVeiculo(int userId, VeiculoDto model);
        Task<VeiculoDto?> UpdateVeiculo(int userId, int veiculoId, VeiculoDto model);
        Task<bool> DeleteVeiculo(int userId, int veiculoId);

        Task<VeiculoDto[]> GetAllVeiculosAsync(int userId);
        Task<VeiculoDto?> GetVeiculoByIdAsync(int userId, int veiculoId);
        Task<VeiculoDto[]> GetAllVeiculoByMarcaAsync(int userId, string marca);
    }
}
