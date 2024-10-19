using Infrastructure.ExternalApi.Emails;
using System.Net.Mail;

namespace Infrastructure.ExternalApi.Email;

public class EmailSender : IEmail
{
    public void Send(string from, string to, string subject, string messageText)
    {
        throw new NotImplementedException();
    }

    public void Send(MailMessage message)
    {
        throw new NotImplementedException();
    }

    public void Send(IEnumerable<MailMessage> messages)
    {
        throw new NotImplementedException();
    }
}
