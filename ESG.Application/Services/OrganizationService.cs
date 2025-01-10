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
        private readonly IUserService _userService;        
        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;            
        }
        public async Task AddAsync(OrganizationCreateDto organizationCreateDto)
        {
            if (organizationCreateDto.Id == 0)
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
                var paswrd = organizationCreateDto.Email.Substring(0, organizationCreateDto.Email.IndexOf("@")); 
                var user = new Dto.User.UserCreationRequestDto()
                {
                    FirstName = organizationCreateDto.FirstName,
                    LastName = organizationCreateDto.LatsName!,
                    Password = paswrd,
                    Email = organizationCreateDto.Email,
                    LanguageId = organizationCreateDto.LanguageId,
                    CreatedBy= organizationCreateDto.CreatedBy,
                    CreatedDate = organizationCreateDto.CreatedDate,
                    PhoneNumber = "12345678",
                    OrganizationId = newOrg.Id,
                    RoleId = 2,
                };
                await _userService.Create(user);                
            }

            if (organizationCreateDto.Id > 0)
            {
                var existingOrg = await _unitOfWork.Repository<Organization>().Get(organizationCreateDto.Id);
                if (existingOrg != null)
                {
                    existingOrg.Name = organizationCreateDto.Name;
                    existingOrg.Country = organizationCreateDto.Country;
                    existingOrg.FirstName = organizationCreateDto.FirstName;
                    existingOrg.LatsName = organizationCreateDto.LatsName;
                    existingOrg.StreetNumber = organizationCreateDto.StreetNumber;
                    existingOrg.Email = organizationCreateDto.Email;
                    existingOrg.PostalCode = organizationCreateDto.PostalCode;
                    existingOrg.StreetAddress = organizationCreateDto.StreetAddress;
                    existingOrg.TenantId = organizationCreateDto.TenantId;
                    existingOrg.RegistrationId = organizationCreateDto.RegistrationId;
                    existingOrg.LanguageId = organizationCreateDto.LanguageId;
                    existingOrg.State = organizationCreateDto.State;
                    existingOrg.LastModifiedBy = organizationCreateDto.LastModifiedBy;
                    existingOrg.LastModifiedDate = organizationCreateDto.LastModifiedDate;
                    existingOrg.LogoUrl = organizationCreateDto.LogoUrl;
                    await _unitOfWork.Repository<Organization>().UpdateAsync(organizationCreateDto.Id, existingOrg);
                };
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task<long> Count()
        {
            return await _unitOfWork.Repository<Organization>().Count();
        }

        public async Task<Organization> Delete(long Id)
        {
            var res = await _unitOfWork.Repository<Organization>().Get(o=>o.Id == Id);
            res.State = StateEnum.deleted;
            await _unitOfWork.Repository<Organization>().UpdateAsync(Id, res);
            await _unitOfWork.SaveAsync();
            return res;
        }

        public async Task<IEnumerable<Organization>> GetAll()
        {
            var res = await _unitOfWork.Repository<Organization>().GetAll(o=>o.State == StateEnum.active);
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