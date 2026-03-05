namespace WebApplication1.Services.ServiceImpl
{
   using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
    using System.Text.Json;
    using WebApplication1.Models;

    public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;
        private readonly OpaService _opaService;

    public JwtService(IConfiguration configuration,OpaService opaService)
    {
        _configuration = configuration;
        _opaService=opaService;
    }

    public async Task<string> GenerateToken(string userId, string email, UserRole role)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            var permissions = await _opaService.GetPermissions(role.ToString());
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role.ToString()),
            new Claim("permissions", JsonSerializer.Serialize(permissions), JsonClaimValueTypes.Json)
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                double.Parse(jwtSettings["DurationInMinutes"]!)
            ),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

}
