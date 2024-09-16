using ESG.Application.Common.Interface.Account;
using ESG.Domain.Entities.TenantAndUsers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        public async Task<string> GenerateToken(long userId)
        {
            // Read JWT settings from configuration
            var key = _configuration["Configuration:JwtTokenConfig:Secret"];
            var issuer = _configuration["Configuration:JwtTokenConfig:Issuer"];
            var audience = _configuration["Configuration:JwtTokenConfig:Audience"];
            var expiresInMinutes = int.Parse(_configuration["Configuration:JwtTokenConfig:RefreshTokenExpiration"]); // Token expiration time in minutes

            // Validate configuration values
            if (string.IsNullOrWhiteSpace(key))
                throw new InvalidOperationException("JWT Secret is not configured.");
            if (string.IsNullOrWhiteSpace(issuer))
                throw new InvalidOperationException("JWT Issuer is not configured.");
            if (string.IsNullOrWhiteSpace(audience))
                throw new InvalidOperationException("JWT Audience is not configured.");

            // Create the security key and signing credentials
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create claims (can be extended with more claims if needed)
            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),  // Use standard claim type for user identifier
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            // Create the token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiresInMinutes), // Use UTC time for token expiration
                signingCredentials: credentials
            );

            // Return the generated token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
