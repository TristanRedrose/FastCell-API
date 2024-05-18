namespace FastCell_DAL.Models.DTO.Auth.Response
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
