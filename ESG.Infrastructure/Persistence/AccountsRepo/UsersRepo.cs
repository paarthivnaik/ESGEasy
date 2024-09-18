using ESG.Application.Common.Interface.Account;
using ESG.Domain.Entities.TenantAndUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Infrastructure.Persistence.AccountsRepo
{
    public class UsersRepo : GenericRepository<User>, IUsersRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration? _configuration;
        public UsersRepo(ApplicationDbContext context, IConfiguration? configuration) : base(context)
        {
            _context = context;
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<User?> GetUserDetails(long userId)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(a => a.OrganizationUsers)
                .Include(r => r.Role)
                .Where(u => u.Id == userId )
                .FirstOrDefaultAsync();

            return user;
        }
        public async Task<string> GenerateToken(long userId,string email, long? organizationId, long roleId)
        {
            var key = _configuration["Configuration:JwtTokenConfig:Secret"];
            var issuer = _configuration["Configuration:JwtTokenConfig:Issuer"];
            var audience = _configuration["Configuration:JwtTokenConfig:Audience"];
            var expiresInMinutes = int.Parse(_configuration["Configuration:JwtTokenConfig:RefreshTokenExpiration"]);

            if (string.IsNullOrWhiteSpace(key))
                throw new InvalidOperationException("JWT Secret is not configured.");
            if (string.IsNullOrWhiteSpace(issuer))
                throw new InvalidOperationException("JWT Issuer is not configured.");
            if (string.IsNullOrWhiteSpace(audience))
                throw new InvalidOperationException("JWT Audience is not configured.");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()), 
                //new Claim("UserId", userId.ToString()),
                new Claim("Email", email.ToString()),
                new Claim("OrganizationId", organizationId.ToString()),
                new Claim("RoleId", roleId.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
