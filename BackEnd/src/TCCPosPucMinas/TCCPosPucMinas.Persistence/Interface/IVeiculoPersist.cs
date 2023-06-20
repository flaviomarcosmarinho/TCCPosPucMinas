using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Persistence.Interface
{
    public interface IVeiculoPersist : IPersist
    {     
        Task<Veiculo[]> GetAllVeiculosAsync(int userId);
        Task<Veiculo?> GetVeiculoByIdAsync(int userId, int veiculoId);
        Task<Veiculo[]> GetAllVeiculosByMarcaAsync(int userId, string marca);       
    }
}
