using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using Microsoft.Extensions.Options;

namespace AWS_Simple_Email_Service_With_Dotnet
{
    public class SESService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IAmazonSimpleEmailService _mailService;
        public SESService(IOptions<MailSettings> mailSettings,
            IAmazonSimpleEmailService mailService)
        {
            _mailSettings = mailSettings.Value;
            _mailService = mailService;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var mailBody = new Body(new Content(mailRequest.Body));
            var message = new Message(new Content(mailRequest.Subject), mailBody);
            var destination = new Destination(new List<string> { mailRequest.ToEmail! });
            var request = new SendEmailRequest(_mailSettings.Mail, destination, message);
            await _mailService.SendEmailAsync(request);
        }
    }
}
