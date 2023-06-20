using AutoMapper;
using TCCPosPucMinas.Application.Dtos;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Application.BusinessRule
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaPersist _marcaPersist;
        private readonly IMapper _mapper;

        public MarcaService(IMarcaPersist marcaPersist, IMapper mapper)
        {
            this._marcaPersist = marcaPersist;
            this._mapper = mapper;
        }

        public async Task<MarcaDto?> AddMarca(MarcaDto model)
        {
            try
            {
                var marca = _mapper.Map<Marca>(model); //Mapeamento de Dto para Domain

                _marcaPersist.Add<Marca>(marca);

                if(await _marcaPersist.SaveChangesAsync())
                {
                    var marcaRetorno = await _marcaPersist.GetMarcaByIdAsync(marca.Id);

                    return _mapper.Map<MarcaDto>(marcaRetorno); //Mapeamento Reverso
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); 
            }
        }

        public async Task<MarcaDto?> UpdateMarca(int marcaId, MarcaDto model)
        {
            try
            {
                var marca = await _marcaPersist.GetMarcaByIdAsync(marcaId);
                if (marca != null)
                {
                    model.Id = marca.Id;

                    _mapper.Map(model, marca);

                    _marcaPersist.Update<Marca>(marca);

                    if (await _marcaPersist.SaveChangesAsync())
                    {
                        var marcaRetorno = await _marcaPersist.GetMarcaByIdAsync(marca.Id);

                        return _mapper.Map<MarcaDto>(marcaRetorno);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMarca(int marcaId)
        {
            try
            {
                var marca = await _marcaPersist.GetMarcaByIdAsync(marcaId);
                if (marca == null)
                {
                    throw new Exception("Marca não encontrada!");
                }

                _marcaPersist.Delete<Marca>(marca);
                return await _marcaPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarcaDto[]> GetAllMarcasAsync()
        {
            try
            {
                var marcas = await _marcaPersist.GetAllMarcasAsync(); 
                return _mapper.Map<MarcaDto[]>(marcas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarcaDto?> GetMarcaByIdAsync(int marcaId)
        {
            try
            {
                var marca = await _marcaPersist.GetMarcaByIdAsync(marcaId);
                return _mapper.Map<MarcaDto?>(marca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MarcaDto?> GetMarcaByNomeAsync(string marca)
        {
            try
            {
                var marcaResultado = await _marcaPersist.GetMarcaByNomeAsync(marca);
                return _mapper.Map<MarcaDto?>(marcaResultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
