using FastCell_BAL.Services.AuthService;
using FastCell_DAL.Models.DTO.Auth.Request;
using FastCell_DAL.Models.DTO.Auth.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastCell.Controllers.Controllers
{
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        public AuthController(IAuthService service)
        {
            _authService = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterUserAsync(request, "Customer");
                if (!result.IsSuccess)
                {
                    return BadRequest(result.ErrorResponse);
                }

                return Ok(result.LoginResponse);
            }

            return BadRequest("User registration failed");
        }

        [HttpPost]
        [Authorize(Policy = "RequireEmployeeAccess")]
        [Route("Register/{role}")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationRequest request, [FromRoute] string role)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterUserAsync(request, role);
                if (!result.IsSuccess)
                {
                    return BadRequest(result.ErrorResponse);
                }

                return Ok(result.LoginResponse);
            }

            return BadRequest("User registration failed");
        }

        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUserAsync(request);

                if (!result.IsSuccess)
                {
                    return BadRequest(result);
                }

                return Ok(result.LoginResponse);
            }

            return BadRequest("Login failed");
        }
    }
}
