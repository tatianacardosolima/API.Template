using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Abstractions.Entities;

namespace Template.Domain.Entities
{
    internal class UsuarioPerfil: EntityBase
    {        
        public string Nome { get; set; }
    }
}
