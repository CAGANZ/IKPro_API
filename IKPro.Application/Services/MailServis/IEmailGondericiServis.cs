
namespace IKPro.Application.Services.MailServis
{
    public interface IEmailGondericiServis
    {
        Task EmailGonderAsync(string toEmail, string subject, string body);
        public string GenerateRandomPassword();
    }
}
