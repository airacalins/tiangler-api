namespace Tiangler.Api.Controllers.Dtos
{
    public class UserDto
    {
        public string Username { get; set; } = default!;
        public IList<string> Roles { get; set; } = default!;
        public Guid Id { get; set; } = default!;
        public string Photo { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
