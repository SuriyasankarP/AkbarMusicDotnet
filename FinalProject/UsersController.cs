using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace FinalProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FinalProjectContext _context;
        

        public UsersController(FinalProjectContext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterReq request)
        {
            if(_context.User.Any( u => u.Email == request.Email) && _context.User.Any(u => u.UserName==request.UserName))
            {
                return BadRequest("User Already Exists");
            }
            CreatePasswordHash(request.Password,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var user = new User 
            { Email = request.Email,
              UserName=request.UserName,
              PasswordHash = passwordHash,
              PasswordSalt = passwordSalt,
            
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User Add Successfull");

        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginReq request)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == request.Email);



            if (user == null)
            {
                return BadRequest("User Not Found");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password is incorrect.");
            }

            string token = CreateToken(user);

            return Ok(token);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId",user.Id.ToString()),
                new Claim("UserName",user.UserName),
                new Claim("UserType",user.UserType),



            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ThisIsMySecretKey"));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims : claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
            
        }

    }
}
