using MediatR;
using Template.Shared.Interfaces.IResponse;

namespace Template.Domain.Interface.Request
{
    public interface ICommandRequest: IRequest<IGenericResponse>
    {
    }

    public interface IUniqueIdCommandRequest : IRequest<IGenericResponse>
    {
        Guid UniqueId { get; set; }
    }
}
