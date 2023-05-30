using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Domain.Identity;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Persistence.Repositoty
{
    public class UserPersistence : GeralPersistence, IUserPersist
    {
        public UserPersistence(TCCPosPucMinasContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName.ToLower().Equals(userName.ToLower()));
        }           
    }
}
