
namespace FastCell_DAL.Models.DTO.Auth.Response
{
    public class ErrorResponse
    {
        public IEnumerable<string>? Errors { get; set; }
        public string Message { get; set; }
    }
}
