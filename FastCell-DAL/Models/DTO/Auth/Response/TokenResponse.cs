using System.IdentityModel.Tokens.Jwt;

namespace FastCell_DAL.Models.DTO.Auth.Response
{
    public class TokenResponse
    {
        public JwtSecurityToken Token { get; set; }
        public string TokenAsString { get; set; }
        public string Role { get; set; }
    }
}
