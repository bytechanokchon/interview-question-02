namespace Application.Handlers.Auths.DTOs.Requests
{
    public class RequestLoginDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
