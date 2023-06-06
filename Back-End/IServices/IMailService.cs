using Back_End.Models;

namespace Back_End.IServices
{
    public interface IMailService
    {
        void SendEmailAutorization(User user, string url);
        void SendEmailForgotAutorization(User user, string url);
    }
}
