using MimeKit;

namespace LedIce.Settings.Mail;

public class MailService
{
    public MimeMessage CreateTextMessage(string subject, string text)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("Led Ice", "info@led-ice.ru"));
        message.To.Add(new MailboxAddress("Led Ice", "info@led-ice.ru"));
        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = text
        };

        return message;
    }
}
