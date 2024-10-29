using ESG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Interface.FileUpload
{
    public interface IFileUploadRepo
    {
        Task<UploadedFile?> GetUploadedFileData(long DataModelValueId, bool IsDefaultmodel);
    }
}
