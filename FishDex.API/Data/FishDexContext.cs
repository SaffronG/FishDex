using FishDex.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FishDex.API.Data;

public class FishDexContext : DbContext
{
    public FishDexContext(DbContextOptions<FishDexContext> options) : base(options)
    {
    }

    public DbSet<Fish> Fish { get; set; } = null!;
}
