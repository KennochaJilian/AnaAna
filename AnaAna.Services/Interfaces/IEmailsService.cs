using AnaAna.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaAna.Services.Interfaces
{
    public interface IEmailsService
    {
        void SendEmail(string email, string subject, string htmlMessage);
        void PrepareAndSendCreatingPollEmailAsync(Poll poll);
    }
}
