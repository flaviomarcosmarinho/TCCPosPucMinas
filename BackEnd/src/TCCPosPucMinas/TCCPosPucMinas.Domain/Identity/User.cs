using Microsoft.AspNetCore.Identity;
using TCCPosPucMinas.Domain.Enum;

namespace TCCPosPucMinas.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public FuncaoSistemaEnum Funcao { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
