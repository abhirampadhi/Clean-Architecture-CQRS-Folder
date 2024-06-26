using MyApp.Application.Models;

namespace MyApp.Application.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}