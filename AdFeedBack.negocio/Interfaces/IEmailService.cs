using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, Dictionary<string, string> templateVariables);
    }
}
