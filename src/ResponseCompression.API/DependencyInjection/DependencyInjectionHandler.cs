﻿using ResponseCompression.ApplicationService.Services;
using ResponseCompression.Domain.Interfaces;
using System.IO.Abstractions;

namespace ResponseCompression.API.DependencyInjection;

internal static class DependencyInjectionHandler
{
    internal static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddCorsDependencyInjection();
        services.AddResponseCompressionDependencyInjection();
        services.AddSingleton<IFileSystem, FileSystem>();
        services.AddTransient<IFileService, FileService>();
    }
}
