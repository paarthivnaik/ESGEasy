using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IDimensionsService
    {
        Task AddAsync(Dimensions dimentions);
        Task<Dimensions> UpdateAsync(Dimensions dimentions);
        Task<IEnumerable<Dimensions>> GetAll();
        Task<Dimensions> GetById(long Id);
        Task<bool> Delete(long Id);
    }
}
