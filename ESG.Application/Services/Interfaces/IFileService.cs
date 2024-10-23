using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IFileService
    {
        Task<IFormFile?> GetFileAsync(string fileName, long organizationId, long userId);
        Task SaveFileAsync(IFormFile file, long organizationId, long UserId);
    }
}
