using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Application.BusinessRule
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoPersist _veiculoPersist;

        public VeiculoService(IVeiculoPersist veiculoPersist)
        {
            this._veiculoPersist = veiculoPersist;
        }

        public async Task<Veiculo?> AddVeiculo(Veiculo model)
        {
            try
            {
                _veiculoPersist.Add<Veiculo>(model);
                if (await _veiculoPersist.SaveChangesAsync())
                {
                    return await _veiculoPersist.GetVeiculoByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo?> UpdateVeiculo(int veiculoId, Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoPersist.GetVeiculoByIdAsync(veiculoId);
                if (veiculo != null)
                {
                    model.Id = veiculo.Id;

                    _veiculoPersist.Update(model);

                    if (await _veiculoPersist.SaveChangesAsync())
                    {
                        return await _veiculoPersist.GetVeiculoByIdAsync(model.Id);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVeiculo(int veiculoId)
        {
            try
            {
                var veiculo = await _veiculoPersist.GetVeiculoByIdAsync(veiculoId);
                if (veiculo == null)
                {
                    throw new Exception("Veículo não encontrado!");
                }

                _veiculoPersist.Delete<Veiculo>(veiculo);
                return await _veiculoPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo[]> GetAllVeiculosAsync()
        {
            try
            {
                return await _veiculoPersist.GetAllVeiculosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo?> GetVeiculoByIdAsync(int veiculoId)
        {
            try
            {
                return await _veiculoPersist.GetVeiculoByIdAsync(veiculoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo[]> GetAllVeiculoByMarcaAsync(string marca)
        {
            try
            {
                return await _veiculoPersist.GetAllVeiculosByMarcaAsync(marca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
