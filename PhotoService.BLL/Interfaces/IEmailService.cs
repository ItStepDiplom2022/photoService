using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoService.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string toEmail, string subject, string htmlBody);
    }
}
