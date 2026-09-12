namespace FishDex.Dtos.Models;

public partial class FishDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Length { get; set; }

    public decimal? Weight { get; set; }

    public DateTime? Caught { get; set; }

    public int? Lid { get; set; }

    public string? Notes { get; set; }

    public LocationDTO? LidNavigation { get; set; }
}
