using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCPosPucMinas.Domain.Enum;

namespace TCCPosPucMinas.Domain.Identity
{
    public class User
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public FuncaoSistemaEnum Funcao { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
