using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Persistence.Repositoty
{
    public class GeralPersistence : IPersist
    {
        protected readonly TCCPosPucMinasContext _context;

        public GeralPersistence(TCCPosPucMinasContext context)
        {
            _context = context;
        }

        #region Metodos Gerais

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        #endregion        
    }
}
