namespace AWS_Simple_Email_Service_With_Dotnet
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
