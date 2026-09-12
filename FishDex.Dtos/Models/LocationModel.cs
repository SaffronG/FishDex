namespace FishDex.Dtos.Models;

public record LocationModel
{
    public required string Name { get; set; }
    public string? County { get; set; }
}