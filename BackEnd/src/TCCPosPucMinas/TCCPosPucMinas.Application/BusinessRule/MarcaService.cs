using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Application.BusinessRule
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaPersist _marcaPersist;

        public MarcaService(IMarcaPersist marcaPersist)
        {
            this._marcaPersist = marcaPersist;
        }

        public async Task<Marca?> AddMarca(Marca model)
        {
            try
            {
                _marcaPersist.Add<Marca>(model);
                if(await _marcaPersist.SaveChangesAsync())
                {
                    return await _marcaPersist.GetMarcaByIdAsync(model.Id);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message); 
            }
        }

        public async Task<Marca?> UpdateMarca(int marcaId, Marca model)
        {
            try
            {
                var marca = await _marcaPersist.GetMarcaByIdAsync(marcaId);
                if (marca != null)
                {
                    model.Id = marca.Id;

                    _marcaPersist.Update(model);

                    if (await _marcaPersist.SaveChangesAsync())
                    {
                        return await _marcaPersist.GetMarcaByIdAsync(model.Id);
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

        public async Task<Marca[]> GetAllMarcasAsync()
        {
            try
            {
                return await _marcaPersist.GetAllMarcasAsync();          
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marca?> GetMarcaByIdAsync(int marcaId)
        {
            try
            {
                return await _marcaPersist.GetMarcaByIdAsync(marcaId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marca?> GetMarcaByNomeAsync(string marca)
        {
            try
            {
                return await _marcaPersist.GetMarcaByNomeAsync(marca);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
