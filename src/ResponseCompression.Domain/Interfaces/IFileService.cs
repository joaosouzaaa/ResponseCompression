using ResponseCompression.Domain.DataTransferObjects.Files;

namespace ResponseCompression.Domain.Interfaces;

public interface IFileService
{
    Task<List<FileResponse>> GetAllFilesAsync(CancellationToken cancellationToken);
}
