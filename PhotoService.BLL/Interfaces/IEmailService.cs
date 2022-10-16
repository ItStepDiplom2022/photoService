namespace PhotoService.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string toEmail, string subject, string htmlBody);
    }
}
