using LedIce.Settings.Mail;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LedIce.Pages.Contacts;

public sealed class IndexModel : PageModel
{
    private readonly MailService _mailService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(MailService mailService, ILogger<IndexModel> logger)
    {
        Input = new();
        _mailService = mailService;
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public void OnPost()
    {
        if (!ModelState.IsValid)
        {
            return;
        }

        var message = _mailService.CreateTextMessage("Обратная связь", Input.Message);

        _logger.LogInformation(message.TextBody);
    }
}
