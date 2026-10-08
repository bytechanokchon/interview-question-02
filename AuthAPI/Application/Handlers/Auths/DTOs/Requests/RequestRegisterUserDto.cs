namespace Application.Handlers.Auths.DTOs.Requests
{
    public class RequestRegisterUserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
