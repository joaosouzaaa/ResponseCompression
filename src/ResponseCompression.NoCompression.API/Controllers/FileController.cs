using Microsoft.AspNetCore.Mvc;
using ResponseCompression.Domain.DataTransferObjects.Files;
using ResponseCompression.Domain.Interfaces;

namespace ResponseCompression.NoCompression.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class FileController(IFileService fileService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FileResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task<List<FileResponse>> GetAllFilesAsync(CancellationToken cancellationToken) =>
        fileService.GetAllFilesAsync(cancellationToken);
}
