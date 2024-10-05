using ResponseCompression.ApplicationService.Services;
using ResponseCompression.Domain.Interfaces;
using System.IO.Abstractions;

namespace ResponseCompression.NoCompression.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddCorsDependencyInjection();
        services.AddSingleton<IFileSystem, FileSystem>();
        services.AddTransient<IFileService, FileService>();
    }
}
