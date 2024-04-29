using Template.DatabaseRepository.Repositories;
using Template.Domain.Interface.IRepositories;

namespace Template.API.Setup
{
    public static class RepositorySetup
    {
        public static void AddDependencyRepository(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICorretorRepository, CorretorRepository>();

        }
    }
}
