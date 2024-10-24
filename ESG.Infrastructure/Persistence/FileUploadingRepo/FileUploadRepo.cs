using ESG.Application.Common.Interface.FileUpload;
using ESG.Application.Common.Interface.Hierarchy;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.FileUploadingRepo
{
    public class FileUploadRepo : GenericRepository<UploadedFile>, IFileUploadRepo
    {
        private readonly ApplicationDbContext _context;
        public FileUploadRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UploadedFile?> GetUploadedFileData(string fileName, long organizationId)
        {
            var file = await _context.UploadedFiles
                .AsNoTracking()
                .Where(a => a.OrganizationId == organizationId && a.FileName == fileName)
                .FirstOrDefaultAsync();
            return file;
        }

        public Task SaveUploadedFileDataInDb(UploadedFile uploadedFile)
        {
            throw new NotImplementedException();
        }
    }
}
