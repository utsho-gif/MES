using Microsoft.IdentityModel.Tokens;
using MES.Core.Setting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MES.Core.Services
{
    public class JWTService : IJWTService
    {
        public string GenerateJwtToken(string name, string userName, int roleId, string employeeId, string email, string terminalId = null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName ?? ""),
                new Claim(ClaimTypes.Role, roleId.ToString()),
                new Claim(ClaimTypes.Email, email ?? ""),
                new Claim(ClaimTypes.Surname, name ?? ""),
                new Claim(ClaimTypes.GroupSid, roleId.ToString()),
                new Claim(ClaimTypes.PrimarySid, employeeId ?? ""),
                new Claim("TerminalId", terminalId ?? "")
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@MES345EnterpriseCoreToken2026"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "MES_API",
                audience: "MES_CLIENT",
                claims: claims,
                expires: DateTime.Now.AddMinutes(ApplicationSettings.TokenExpireMinutes),
                signingCredentials: signinCredentials
            );

            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public string GenerateTerminalToken(string terminalId, int deviceType, int plantId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, terminalId ?? ""),
                new Claim("DeviceType", deviceType.ToString()),
                new Claim("PlantId", plantId.ToString())
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@MES345EnterpriseCoreToken2026"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "MES_API",
                audience: "MES_CLIENT",
                claims: claims,
                expires: DateTime.Now.AddMinutes(ApplicationSettings.TokenExpireMinutes),
                signingCredentials: signinCredentials
            );

            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
