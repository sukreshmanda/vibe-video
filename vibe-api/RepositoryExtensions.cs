using vibe_api.Entity.SmallVideo;
using vibe_api.Entity.Token;
using vibe_api.Repository;
using vibe_api.Validator;

namespace vibe_api;

public static class RepositoryExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<UploadToken>, RepositoryBase<UploadToken>>();
        services.AddScoped<IRepository<SmallVideo>, RepositoryBase<SmallVideo>>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<IFormFile>, SmallVideoFormFileValidator>();
    }
}