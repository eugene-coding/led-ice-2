using System.ComponentModel.DataAnnotations;

namespace LedIce.Pages.Contacts;

public sealed class InputModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; } = string.Empty;

    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.MultilineText)]
    public string Message { get; set; } = string.Empty;

    [Required]
    public bool Agreed { get; set; }

    public void Clear()
    {
        Name = string.Empty;
        Phone = string.Empty;
        Email = string.Empty;
        Message = string.Empty;
        Agreed = false;
    }
}
