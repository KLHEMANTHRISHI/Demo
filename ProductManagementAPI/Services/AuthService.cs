﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductManagementAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementAPI.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly NorthwindContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(NorthwindContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        /* public string Authenticate(string username, string password)
         {
           var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == username && u.Passwordhash == password);
             if (user == null) return null;

             var tokenHandler = new JwtSecurityTokenHandler();
             var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[] {
                         new Claim(ClaimTypes.Name, user.Username),
                         new Claim(ClaimTypes.Role, user.Role.Name)
                       }),
                 Expires = DateTime.UtcNow.AddDays(7),
                 SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
             };
             var token = tokenHandler.CreateToken(tokenDescriptor);
             return tokenHandler.WriteToken(token);

         }*/
        public string Authenticate(string username, string password)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == username && u.Passwordhash == password);
            if (user == null) return null;
            Console.WriteLine(user.Role.Name);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.Name)
        }),
                Expires = DateTime.UtcNow.AddDays(7),
                Audience = _configuration["Jwt:Audience"],  // Ensure the Audience is set
                Issuer = _configuration["Jwt:Issuer"],      // Ensure the Issuer is set
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}