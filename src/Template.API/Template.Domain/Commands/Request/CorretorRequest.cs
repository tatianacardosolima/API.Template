using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Template.Domain.Interface.Request;

namespace Template.Domain.Commands.Request
{
    public class NewCorretorRequest : CorretorRequest,ICommandRequest
    {

    }

    public class UpdCorretorRequest : CorretorRequest, IUniqueIdCommandRequest
    {
        public Guid UniqueId { get; set; }
    }

    public class CorretorRequest: PessoaRequest
    {
        public double Comissao { get; set; }
    }

    public class DelCorretorRequest: CorretorByUniqueId, IUniqueIdCommandRequest
    {
        public DelCorretorRequest(Guid uniqueId): base(uniqueId)
        {            
        }
    }
    public class CorretorByUniqueId 
    {
        public CorretorByUniqueId()
        {
        }
        public CorretorByUniqueId(Guid uniqueId )
        {
            UniqueId = uniqueId;
        }
        public Guid UniqueId { get; set; }
    }
}
