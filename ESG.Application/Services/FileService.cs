using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Common.Interface.FileUpload;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IFormFile?> GetFileAsync(string fileName, long organizationId)
        {
            var uploadedFile = await _unitOfWork.FileUploadRepo.GetUploadedFileData(fileName, organizationId);
            if (uploadedFile == null)
            {
                return null;
            }
            var memoryStream = new MemoryStream(uploadedFile.FileData);
            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "file", uploadedFile.FileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf" // Set default content type
            };
            return formFile;
        }



        public async Task SaveFileAsync(IFormFile file, long organizationId, long userId)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File cannot be null or empty.");
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var uploadedFile = new UploadedFile
                {
                    FileName = file.FileName,
                    FileData = memoryStream.ToArray(),
                    OrganizationId = organizationId,
                    UserId = userId,
                    UploadDate = DateTime.UtcNow.ToLocalTime(),
                };
               await _unitOfWork.Repository<UploadedFile>().AddAsync(uploadedFile);
               await _unitOfWork.SaveAsync();
            }
        }
        public async Task<byte[]?> GetFileDataAsync(string fileName, long organizationId)
        {
            var uploadedFile = await _unitOfWork.FileUploadRepo.GetUploadedFileData(fileName, organizationId);
            return uploadedFile?.FileData;
        }
    }
}
