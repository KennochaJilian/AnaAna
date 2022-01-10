using AnaAna.Data.Models;
using AnaAna.RazorHtmlEmails.Interfaces;
using AnaAna.RazorHtmlEmails.Views.CreatePoll;
using AnaAna.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Text;



namespace AnaAna.Services
{
    public class EmailsService : IEmailsService
    {
        private readonly IConfiguration Configuration;
        private readonly IRazorViewToStringRender _razorViewToStringRenderer;
        public EmailsService(IConfiguration configuration, IRazorViewToStringRender razorViewToStringRenderer)
        {
            Configuration = configuration;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }
        public void SendEmail(string email, string subject, string htmlMessage)
        {
            string to = email; //To address
            string from = "anaanacci@outlook.fr"; //From address
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = htmlMessage;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Gmail smtp
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(Configuration["ConnectionEmail:emailAdress"], Configuration["ConnectionEmail:emailPassword"]);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            client.Send(message);
        }

        public async void PrepareAndSendCreatingPollEmailAsync(Poll poll)
        {
            string subject = $"Le sondage {poll.Title} a été créé";
            string htmlMessage = await _razorViewToStringRenderer.RenderViewToStringAsync(
                "~/Views/Emails/CreatePoll/CreatePollEmail.cshtml", 
                new CreatePollEmailViewModel(poll));  

            SendEmail(poll.CreatedBy.Email, subject, htmlMessage);
        }

    }
}
