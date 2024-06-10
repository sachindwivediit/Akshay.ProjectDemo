using Akshay.ProjectDemo.API.Interface;
using Akshay.ProjectDemo.Entities;
using Akshay.ProjectDemo.Repository;
using Akshay.ProjectDemo.API.RequestModfels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Akshay.ProjectDemo.API.Service
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        public User AddUser(User user)
        {
            var addedUser = _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
            return addedUser.Entity;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (!string.IsNullOrEmpty(loginRequest.UserName) && !string.IsNullOrEmpty(loginRequest.Password))
            {
                var user = _applicationDbContext.Users.SingleOrDefault(x => x.Email == loginRequest.UserName && x.Password == loginRequest.Password);

                if (user != null)
                {
                    var jwtToken = GenerateToken(user, _configuration);
                    return jwtToken;
                }
                else
                {
                    throw new Exception("User is not Valid");
                }
            }
            else
            {
                throw new Exception("Credentials are not valid ");
            }
        }

        private static string GenerateToken(User user, IConfiguration configuration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                
                signingCredentials: credentials,
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["JWT:Subject"]),
                 new Claim("Id",user.Id.ToString()),
                  new Claim("UserName",user.Name),
                   new Claim("Email",user.Email)
                },
                  expires: DateTime.Now.AddMinutes(1)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
