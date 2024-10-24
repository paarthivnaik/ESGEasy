using ESG.Application.Common.Interface.FileUpload;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ESG.API.Controllers
{
    public class FileController : Controller
    {
        private readonly ILogger<FileController> _logger;
        private readonly IFileService _fileService;
        public FileController(ILogger<FileController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }
        [HttpGet("GetUploadedFile")]
        public async Task<IActionResult> GetFile(string fileName, long organizationId, long userId)
        {
            try
            {
                var fileData = await _fileService.GetFileDataAsync(fileName, organizationId);
                if (fileData == null)
                    return Ok(new { error = true, errorMsg = "File not found" });

                var memoryStream = new MemoryStream(fileData);
                var contentType = "application/pdf";
                var result = new FileStreamResult(memoryStream, contentType)
                {
                    FileDownloadName = null
                };
                Response.Headers.Add("Content-Disposition", $"inline; filename=\"{fileName}\"");
                return Ok( new { error = true, errorMsg = "An error occurred while retrieving the file.", result});
            }
            catch (Exception ex)
            {
                return Ok( new { error = true, errorMsg = "An error occurred while retrieving the file.", details = ex.Message });
            }
        }


        [HttpPost("UploadFile")]
        public async Task<IActionResult> SaveFileAsync(IFormFile uploadingfile, long organizationId, long userId)
        {
            try
            {
                await _fileService.SaveFileAsync(uploadingfile, organizationId, userId);
                return Ok(new { error = false, errorMsg = "File has been uploaded....." });
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }

    }
}
