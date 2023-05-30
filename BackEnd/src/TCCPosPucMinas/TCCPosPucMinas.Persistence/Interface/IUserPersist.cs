using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPosPucMinas.Domain.Identity;

namespace TCCPosPucMinas.Persistence.Interface
{
    public interface IUserPersist : IPersist
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task<User?> GetUserByUserNameAsync(string username);
    }
}
