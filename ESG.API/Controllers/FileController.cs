using ESG.Application.Common.Interface.FileUpload;
using ESG.Application.Services;
using ESG.Application.Services.Interfaces;
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
                var uploadedFile = await _fileService.GetFileAsync(fileName, organizationId, userId);

                if (uploadedFile == null)
                    return Ok(new { error = true, errorMsg = "File not found" });

                //return File(uploadedFile.FileName, "application/pdf", uploadedFile.FileName);
                return File(uploadedFile.OpenReadStream(), uploadedFile.ContentType, uploadedFile.FileName);

            }
            catch (FileNotFoundException ex)
            {
                return Ok(new { error = true, errorMsg = "File not found" });
            }
        }

        [HttpGet("UploadFile")]
        public async Task<IActionResult> SaveFileAsync(IFormFile uploadingfile, long organizationId, long userId)
        {
            try
            {
                await _fileService.SaveFileAsync(uploadingfile, organizationId, userId);
                return Ok(new { error = false, errorMsg = "File has been uploaded....."});
            }
            catch (Exception ex)
            {
                return Ok(new { error = true, errorMsg = ex.Message });
            }
        }

    }
}
