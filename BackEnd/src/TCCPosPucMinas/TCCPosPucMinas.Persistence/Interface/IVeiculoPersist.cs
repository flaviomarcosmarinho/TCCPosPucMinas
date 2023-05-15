using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Persistence.Interface
{
    public interface IVeiculoPersist : IPersist
    {     
        Task<Veiculo[]> GetAllVeiculosAsync();
        Task<Veiculo?> GetVeiculoByIdAsync(int veiculoId);
        Task<Veiculo[]> GetAllVeiculosByMarcaAsync(string marca);       
    }
}
