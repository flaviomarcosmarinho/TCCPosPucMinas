using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Application.Interface
{
    public interface IVeiculoService
    {
        Task<Veiculo?> AddVeiculo(Veiculo model);
        Task<Veiculo?> UpdateVeiculo(int veiculoId, Veiculo model);
        Task<bool> DeleteVeiculo(int veiculoId);

        Task<Veiculo[]> GetAllVeiculosAsync();
        Task<Veiculo?> GetVeiculoByIdAsync(int veiculoId);
        Task<Veiculo[]> GetAllVeiculoByMarcaAsync(string marca);
    }
}
