using Domain.Dto.FileManager;
using Microsoft.AspNetCore.Mvc;

namespace EvoMarket.FileManager.Api.Controllers;

[Route("/[controller]/[action]")]
public class FileManagerController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileManagerController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    [HttpPost]
    public async Task<FileDto> UploadFile([FromForm] UploadDto uploadDto)
    {
        string fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(uploadDto.File.FileName)}";

        FileStream stream = new FileStream(Path.Combine(this._webHostEnvironment.WebRootPath, fileName),
            FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

        await uploadDto.File.CopyToAsync(stream);
        
        stream.Close();
        return new FileDto()
        {
            Url = "/" + fileName
        };
    }
}