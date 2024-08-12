﻿using ESG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task AddAsync(Organization organization);
        Task<Organization> UpdateAsync(Organization organization);
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization> GetById(long Id);
        Task<long> Count();
        Task<Organization> Delete(long Id);
    }
}