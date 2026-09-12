namespace FishDex.Dtos.Models;

public class FishModel
{
    public string Name { get; set; } = "";
    public decimal Length { get; set; }
    public decimal Weight { get; set; }
    public DateTime TimeCaught { get; set; }
    public LocationModel? LocationCaught { get; set; } = null;
    public string? Notes { get; set; } = null;
}
