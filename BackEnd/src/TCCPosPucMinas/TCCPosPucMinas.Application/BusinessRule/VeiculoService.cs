using AutoMapper;
using TCCPosPucMinas.Application.Dtos;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Application.BusinessRule
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoPersist _veiculoPersist;
        private readonly IMapper _mapper;

        public VeiculoService(IVeiculoPersist veiculoPersist, IMapper mapper)
        {
            this._veiculoPersist = veiculoPersist;
            this._mapper = mapper;
        }

        public async Task<VeiculoDto?> AddVeiculo(int userId, VeiculoDto model)
        {
            try
            {
                var veiculo = _mapper.Map<Veiculo>(model); //Mapeamento de Dto para Domain

                _veiculoPersist.Add<Veiculo>(veiculo); 

                if (await _veiculoPersist.SaveChangesAsync())
                {
                    var veiculoRetorno = await _veiculoPersist.GetVeiculoByIdAsync(userId, veiculo.Id);

                    return _mapper.Map<VeiculoDto>(veiculoRetorno); //Mapeamento Reverso
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<VeiculoDto?> UpdateVeiculo(int userId, int veiculoId, VeiculoDto model)
        {
            try
            {
                var veiculo = await _veiculoPersist.GetVeiculoByIdAsync(userId, veiculoId);
                if (veiculo != null)
                {
                    model.Id = veiculo.Id;

                    _mapper.Map(model, veiculo);

                    _veiculoPersist.Update<Veiculo>(veiculo);

                    if (await _veiculoPersist.SaveChangesAsync())
                    {
                        var veiculoRetorno = await _veiculoPersist.GetVeiculoByIdAsync(userId, veiculo.Id);

                        return _mapper.Map<VeiculoDto>(veiculoRetorno);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVeiculo(int userId, int veiculoId)
        {
            try
            {
                var veiculo = await _veiculoPersist.GetVeiculoByIdAsync(userId, veiculoId);
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

        public async Task<VeiculoDto[]> GetAllVeiculosAsync(int userId)
        {
            try
            {
                var veiculos = await _veiculoPersist.GetAllVeiculosAsync(userId);
                var resultado = _mapper.Map<VeiculoDto[]>(veiculos);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VeiculoDto[]> GetAllVeiculoByMarcaAsync(int userId, string marca)
        {
            try
            {
                var veiculos = await _veiculoPersist.GetAllVeiculosByMarcaAsync(userId, marca);
                var resultado = _mapper.Map<VeiculoDto[]>(veiculos);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VeiculoDto?> GetVeiculoByIdAsync(int userId, int veiculoId)
        {
            try
            {
                var veiculo = await _veiculoPersist.GetVeiculoByIdAsync(userId, veiculoId);
                var resultado = _mapper.Map<VeiculoDto>(veiculo);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }               
    }
}
