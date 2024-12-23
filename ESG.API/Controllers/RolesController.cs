﻿using ESG.Application.Services.Interfaces;
using ESG.Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace ESG.API.Controllers
{

    public class RolesController : BaseController
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleService  _roleService;
        public RolesController(ILogger<RolesController> logger, IRoleService  roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IEnumerable<Role>> Get()
        {
             return await _roleService.GetAll();
        }

        //[HttpGet("{id}")]
        //public async Task<Role> Get(int id)
        //{
        //    return await _roleService.GetById(id);
        //}

        //[HttpPost]
        //public async Task Post([FromBody] Role value)
        //{
        //    await _roleService.AddAsync(value);
        //}

        //[HttpPut("{id}")]
        //public async Task<Role> Put([FromBody] Role value)
        //{
        //    var res = await _roleService.UpdateAsync(value);
        //    return res;
        //}

        //[HttpDelete("{id}")]
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var res = await _roleService.DeleteAsync(id);
        //    return res;
        //}
    }
}
