using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IFileService
    {
        Task<IFormFile?> GetFileAsync(string fileName, long organizationId);
        Task SaveFileAsync(IFormFile file, long organizationId, long UserId);
        Task<byte[]?> GetFileDataAsync(string fileName, long organizationId);
    }
}
