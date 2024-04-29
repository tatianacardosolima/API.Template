using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.Interfaces.IResponse
{
    public interface IGenericResponse
    {
        bool Success { get; set; }

        string Message { get; set; }

        object Data { get; set; }
    }
}
