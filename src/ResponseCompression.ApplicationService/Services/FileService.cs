using ResponseCompression.Domain.DataTransferObjects.Files;
using ResponseCompression.Domain.Interfaces;
using System.IO.Abstractions;

namespace ResponseCompression.ApplicationService.Services;

public sealed class FileService(IFileSystem fileSystem) : IFileService
{
    public async Task<List<FileResponse>> GetAllFilesAsync(CancellationToken cancellationToken)
    {
        var folderPath = fileSystem.Path.Combine(AppContext.BaseDirectory, "Files");
        var files = fileSystem.Directory.GetFiles(folderPath);

        var fileResponseList = new List<FileResponse>();

        foreach (var file in files)
        {
            var fileBytes = await fileSystem.File.ReadAllBytesAsync(file, cancellationToken);

            fileResponseList.Add(new FileResponse(
                file,
                fileBytes));
        }

        return fileResponseList;
    }
}
