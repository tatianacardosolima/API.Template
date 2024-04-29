using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.Interfaces.IResponse;

namespace Template.Domain.Commands.Response
{
    public class GenericResponse: IGenericResponse
    {
        public GenericResponse(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public GenericResponse(bool success, string message)
        {
            Success = success;
            Message = message;

        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
