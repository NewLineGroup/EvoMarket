using Microsoft.AspNetCore.Http;

namespace Domain.Dto.FileManager;

public record UploadDto
{
    public IFormFile File { get; set; }
    public string FileName { get; set; }
}