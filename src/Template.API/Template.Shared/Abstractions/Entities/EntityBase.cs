using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Interfaces.IEntities;

namespace Template.Shared.Abstractions.Entities
{
    public abstract class EntityBase: IEntity
    {
        public int Id { get; set; }
    }
}
