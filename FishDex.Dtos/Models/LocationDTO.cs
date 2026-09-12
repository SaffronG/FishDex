namespace FishDex.Dtos.Models;

public partial class LocationDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? County { get; set; }

    public virtual ICollection<FishDTO> Fish { get; set; } = new List<FishDTO>();
}
