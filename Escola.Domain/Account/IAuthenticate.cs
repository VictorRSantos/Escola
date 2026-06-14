using Escola.Domain.Entities;

namespace Escola.Domain.Account
{
    public interface IAuthenticate
    {
        public string GenerateToken(int id, string email, string role);
        Task<Usuario> GetUsuarioByEmail(string email);
        Task<bool> UserExists(string email);
        Task<bool> AuthenticateAsync(string email, string senha);
    }
}
