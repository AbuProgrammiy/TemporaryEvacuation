using EmailSenderApp.Domen.Entities.AuthModels;

namespace EmailSenderApp.Application.AuthService
{
    public interface IAuthServise
    {
        public string GenerateToken(User user);
    }
}
