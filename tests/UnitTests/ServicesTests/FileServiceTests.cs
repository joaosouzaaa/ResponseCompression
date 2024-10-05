using Moq;
using ResponseCompression.ApplicationService.Services;
using System.IO.Abstractions;

namespace UnitTests.ServicesTests;

public sealed class FileServiceTests
{
    private readonly Mock<IFileSystem> _fileSystemMock;
    private readonly FileService _fileService;

    public FileServiceTests()
    {
        _fileSystemMock = new Mock<IFileSystem>();
        _fileService = new FileService(_fileSystemMock.Object);
    }


}
