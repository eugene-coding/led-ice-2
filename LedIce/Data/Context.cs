using Microsoft.EntityFrameworkCore;

namespace LedIce.Data;

internal sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }
}
