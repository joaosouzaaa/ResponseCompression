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

    [Fact]
    public async Task GetAllFilesAsync_SuccessfulScenario_ReturnsFileResponseList()
    {
        // A
        const string folderPath = "random";
        _fileSystemMock.Setup(f => f.Path.Combine(
            It.IsAny<string[]>()))
            .Returns(folderPath);

        var files = new string[]
        {
            "test",
            "test123"
        };
        _fileSystemMock.Setup(f => f.Directory.GetFiles(
            It.IsAny<string>()))
            .Returns(files);

        var fileBytes = new byte[]
        {
            00,
            92
        };
        _fileSystemMock.SetupSequence(f => f.File.ReadAllBytesAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(fileBytes)
            .ReturnsAsync(fileBytes);

        // A
        var fileResponseListResult = await _fileService.GetAllFilesAsync(default);

        // A
        Assert.Equal(files.Count(), fileResponseListResult.Count);
    }
}
