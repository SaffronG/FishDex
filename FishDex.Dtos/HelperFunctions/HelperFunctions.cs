using FishDex.Dtos.Models;

namespace FishDex.Dtos.HelperFunctions;

public static class HelperFunctions
{
    /// <summary>
    /// Converts a single FishDTO object into a FishModel object
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static FishModel AsModel(this FishDTO dto) => new()
    {
        Name = dto.Name,
        Length = (decimal)dto.Length,
        Weight = (decimal)dto.Weight,
        TimeCaught = (DateTime)dto.Caught,
        LocationCaught = dto.LidNavigation?.AsModel(),
        Notes = dto.Notes,
    };

    /// <summary>
    /// Converts an IEnumerable<FishDTO> collection into a List<FishModel>
    /// </summary>
    /// <param name="dtos"></param>
    /// <returns></returns>
    public static async Task<List<FishModel>> AsModel(this IEnumerable<FishDTO>? dtos)
        => dtos?.Select(d => d.AsModel()).ToList() ?? [];

    /// <summary>
    /// Converts a single LocationDTO object into a LocationModel object
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static LocationModel AsModel(this LocationDTO dto) => new()
    {
        Name = dto.Name,
        County = dto.County,
    };

    /// <summary>
    /// Converts an IEnumerable<LocationDTO> collection into a List<LocationModel>
    /// </summary>
    /// <param name="dtos"></param>
    /// <returns></returns>
    public static async Task<List<LocationModel>> AsModel(this IEnumerable<LocationDTO>? dtos)
        => dtos?.Select(d => d.AsModel()).ToList() ?? [];

}
