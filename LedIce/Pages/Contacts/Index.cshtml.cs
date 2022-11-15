using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LedIce.Pages.Contacts;

public sealed class IndexModel : PageModel
{
    public IndexModel()
    {
        Input = new();
    }

    [BindProperty]
    public InputModel Input { get; set; }
}
