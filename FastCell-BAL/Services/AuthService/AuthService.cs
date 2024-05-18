using FastCell_DAL.Enums;
using FastCell_DAL.Models.DTO.Auth.Request;
using FastCell_DAL.Models.DTO.Auth.Response;
using FastCell_DAL.Models.Entities.Auth;
using FastCell_DAL.Models.Entities.Auth.Info;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FastCell_BAL.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private UserManager<User> _userManager;
        private IConfiguration _configuration;

        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegistrationRequest request, string role)
        {
            if (request == null) throw new NullReferenceException();

            if (request.Password != request.PassConfirm)
            {
                return new UserManagerResponse
                {
                    ErrorResponse = new ErrorResponse
                    {
                        Message = "Passwords must match",
                    },
                    IsSuccess = false,
                };
            }

            var contactInfo = new ContactInfo
            {   
                Name = request.Name,
                Surname = request.Surname,
                Address = request.Adress,
                PhoneNumber = request.Phone,
                City = request.City,
                Country = request.Country,
                PostalCode = request.PostalCode,
            };

            var identityUser = new User
            {
                UserName = request.Email,
                Email = request.Email,
                ContactInfo = contactInfo,
            };

            if (role != "User")
            {
                identityUser.EmployeeInfo = new EmployeeInfo
                {
                    Active = (bool)request.Active!,
                    Position = role,
                    Salary = (int)request.Salary!,
                    EmploymentType = (EmploymentType)request.EmploymentType!,
                };
            }
            

            var result = await _userManager.CreateAsync(identityUser, request.Password);
            await _userManager.AddToRoleAsync(identityUser, role);

            if (result.Succeeded)
            {
                var tokenResponse = await GenerateTokenAsync(identityUser);
                return new UserManagerResponse
                {
                    IsSuccess = true,
                    LoginResponse = new LoginResponse
                    {
                        Token = tokenResponse.TokenAsString,
                        ExpireDate = tokenResponse.Token.ValidTo,
                        Username = identityUser.UserName,
                        Role = tokenResponse.Role,
                    }
                };
            }

            return new UserManagerResponse
            {
                IsSuccess = false,
                ErrorResponse = new ErrorResponse
                {
                    Message = "User registration failed",
                    Errors = result.Errors.Select(e => e.Description),
                }
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    ErrorResponse = new ErrorResponse
                    {
                        Message = "Login failed",
                    },
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    ErrorResponse = new ErrorResponse
                    {
                        Message = "Login failed",
                    },
                    IsSuccess = false,
                };
            }

            var tokenResponse = await GenerateTokenAsync(user);

            return new UserManagerResponse
            {
                IsSuccess = true,
                LoginResponse = new LoginResponse
                {
                    Token = tokenResponse.TokenAsString,
                    ExpireDate = tokenResponse.Token.ValidTo,
                    Username = user.UserName,
                    Role = tokenResponse.Role,
                }
            };
        }

        public async Task<TokenResponse> GenerateTokenAsync(User user)
        {

            var userRoles = await _userManager.GetRolesAsync(user);
            var userRole = userRoles.FirstOrDefault();

            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, userRole)
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenResponse
            {
                Token = token,
                TokenAsString = tokenAsString,
                Role = userRole
            };
        }
    }


}
