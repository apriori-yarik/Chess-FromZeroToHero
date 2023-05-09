using Chess_FromZeroToHero.Contracts.Dtos;
using Chess_FromZeroToHero.Contracts.Dtos.User;
using Chess_FromZeroToHero.DataAccess.Repositories;
using Chess_FromZeroToHero.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;
        private readonly JWTSettingsDto _jwtSettingsDto;

        public AuthService(UserRepository userRepository, JWTSettingsDto jwtSettingsDto)
        {
            _userRepository = userRepository;
            _jwtSettingsDto = jwtSettingsDto;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var users = await _userRepository.GetAllFilteredAsync(x => x.Username == username);

            if (users == null || users.Count == 0)
            {
                return null;
            }

            var user = users.FirstOrDefault();

            var isVerified = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!isVerified)
            {
                return null;
            }

            var token = GenerateToken(user);

            return token;
        }

        public async Task RegisterAsync(UserDto userDto)
        {
            userDto.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            await _userRepository.CreateAsync(userDto);
        }

        private string GenerateToken(UserWithIdDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettingsDto.Key));
            var credentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: _jwtSettingsDto.Issuer,
                audience: _jwtSettingsDto.Audience,
                expires: DateTime.Now.AddHours(int.Parse(_jwtSettingsDto.Expiration)),
                claims: GetClaims(userDto),
                signingCredentials: credentials);

            return tokenHandler.WriteToken(token);
        }


        private List<Claim> GetClaims(UserWithIdDto userDto)
        {
            return new List<Claim>
            {
                new Claim("id", userDto.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, userDto.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        }

    }
}
