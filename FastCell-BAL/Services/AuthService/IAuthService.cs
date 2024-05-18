using FastCell_DAL.Models.DTO.Auth.Request;
using FastCell_DAL.Models.DTO.Auth.Response;

namespace FastCell_BAL.Services.AuthService
{
    public interface IAuthService
    {
        public Task<UserManagerResponse> RegisterUserAsync(RegistrationRequest request, string role);
        public Task<UserManagerResponse> LoginUserAsync(LoginRequest request);
    }
}
