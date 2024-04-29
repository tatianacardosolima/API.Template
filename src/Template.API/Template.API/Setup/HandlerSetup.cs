using MediatR;
using Template.Domain.Commands.Request;
using Template.Domain.Handlers.Corretores;
using Template.Shared.Interfaces.IResponse;

namespace Template.API.Setup
{
    public static class HandlerSetup
    {
        public static void AddDependencyHandler(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<IRequestHandler<NewCorretorRequest, IGenericResponse>, AddNewCorretorHandler>();

        }
    }
}
