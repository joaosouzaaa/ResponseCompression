using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace ResponseCompression.API.DependencyInjection;

internal static class ResponseCompressionDependencyInjection
{
    internal static void AddResponseCompressionDependencyInjection(this IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
        });

        services.Configure<BrotliCompressionProviderOptions>(options =>
            options.Level = CompressionLevel.Optimal);
        
        services.Configure<GzipCompressionProviderOptions>(options =>
            options.Level = CompressionLevel.SmallestSize);
    }
}
