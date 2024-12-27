using AutoMapper;
using ESG.Application.Common.Interface;
using ESG.Application.Dto.Organization;
using ESG.Application.Services.Interfaces;
using ESG.Domain.Enum;
using ESG.Domain.Models;

namespace ESG.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(OrganizationCreateDto organizationCreateDto)
        {
            var newOrg = new Domain.Models.Organization
            {
                Name = organizationCreateDto.Name,
                Country = organizationCreateDto.Country,
                FirstName = organizationCreateDto.FirstName,
                LatsName = organizationCreateDto.LatsName,
                StreetNumber = organizationCreateDto.StreetNumber,
                Email = organizationCreateDto.Email,
                CreatedDate = organizationCreateDto.CreatedDate,
                PostalCode = organizationCreateDto.PostalCode,
                StreetAddress = organizationCreateDto.StreetAddress,
                TenantId = organizationCreateDto.TenantId,
                RegistrationId = organizationCreateDto.RegistrationId,
                LanguageId = organizationCreateDto.LanguageId,
                State = organizationCreateDto.State,
                LastModifiedBy = organizationCreateDto.LastModifiedBy,
                LastModifiedDate = organizationCreateDto.LastModifiedDate,
                CreatedBy = organizationCreateDto.CreatedBy,
                LogoUrl = organizationCreateDto.LogoUrl
            };


            await _unitOfWork.Repository<Organization>().AddAsync(newOrg);
            await _unitOfWork.SaveAsync();
        }

        public async Task<long> Count()
        {
            return await _unitOfWork.Repository<Organization>().Count();
        }

        public async Task<Organization> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<Organization>().Get(Id);
            res.State = StateEnum.deleted;
            await _unitOfWork.Repository<Organization>().UpdateAsync(Id, res);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<IEnumerable<Organization>> GetAll()
        {
            var res = await _unitOfWork.Repository<Organization>().GetAll();
            return res;
        }

        public async Task<Organization> GetById(long Id)
        {
            var res = await _unitOfWork.Repository<Organization>().Get(Id);
            return res;
        }


        public async Task<Organization> UpdateAsync(Organization organization)
        {
            var res = await _unitOfWork.Repository<Organization>().UpdateAsync(organization.Id, organization);
            return res;
        }
        public async Task<List<OrganizationUsersResponseDto>> GetOrganizationalUsers(long Id)
        {
            var response = new List<OrganizationUsersResponseDto>();
            var res = await _unitOfWork.OrganizationRepo.GetOrganizationUsers(Id);
            foreach (var user in res)
            {
                var obj = new OrganizationUsersResponseDto
                {
                    UserId = user.UserId,
                    FirstName = user.User.FirstName,
                    LastName = user.User.LastName,
                };
                response.Add(obj);
            }
            return response;
        }
    }
}