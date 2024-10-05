namespace ResponseCompression.Domain.DataTransferObjects.Files;

public sealed record FileResponse(
    string FileName,
    byte[] FileContent);
