using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services
{
    public class DimensionsService : IDimensionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DimensionsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Dimensions> AddAsync(Dimensions dimentions)
        {
            var res = await _unitOfWork.Repository<Dimensions>().AddAsync(dimentions);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<bool> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<Dimensions>().Delete(Id);
            return res;
        }

        public async Task<IEnumerable<Dimensions>> GetAll()
        {
            return await _unitOfWork.Repository<Dimensions>().GetAll();
        }

        public async Task<Dimensions> GetById(long Id)
        {
            return await _unitOfWork.Repository<Dimensions>().Get(Id);
        }

        public async Task<Dimensions> UpdateAsync(Dimensions dimentions)
        {
            var res = await _unitOfWork.Repository<Dimensions>().Update(dimentions);
            await _unitOfWork.SaveAsync();
            return res;
        }
    }
}

