using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
        public FileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

       
        public async Task<IFormFile?> GetFileAsync(string fileName, long organizationId, long userId)
        {
            var uploadedFile = await _unitOfWork.Repository<UploadedFile>()
                .Get(a => a.FileName == fileName && a.OrganizationId == organizationId && a.UserId == userId);
            if (uploadedFile == null)
            {
                return null;
            }
            var memoryStream = new MemoryStream(uploadedFile.FileData);
            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, "file", uploadedFile.FileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf" 
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
                    UploadDate = DateTime.UtcNow
                };
               await _unitOfWork.Repository<UploadedFile>().AddAsync(uploadedFile);
               await _unitOfWork.SaveAsync();
            }
        }
    }
}
