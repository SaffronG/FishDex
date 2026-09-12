using FishDex.Dtos.HelperFunctions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishDex.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FishController(PostgresContext _db) : ControllerBase
{
    // GET /api/fish
    // GET /api/fish?name=trout
    [HttpGet]
    public async Task<ActionResult<List<FishModel>>> GetByName([FromQuery] string? name)
    {
        var query = _db.Fish.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(name))
            query = _db.Fish.
                Where(fish => EF.Functions.ILike(fish.Name, $"%{name}%"))
                    .Include(f => f.LidNavigation);

        return Ok(await query.OrderBy(f => f.Name).Include(f => f.LidNavigation).AsModel());
    }

    // GET /api/fish?id=2  
    // Fish is a real object with its own Id property)
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<FishModel>>> GetById(int id)
    {
        var fish = _db.Fish.AsNoTracking().Where(f => f.Id == id).Include(f => f.LidNavigation).FirstOrDefault();
        return fish is null ? NotFound() : Ok(fish.AsModel());
    }

    // GET /api/fish/locations
    [HttpGet("locations")]
    public async Task<ActionResult<List<LocationModel>>> GetLocations() => Ok(await _db.Locations.Select(l => l).ToListAsync());

    // POST /api/fish  (body: a raw string, e.g. "Tiger Trout")
    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] FishDTO fish)
    {
        _db.Fish.Add(fish);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), fish.Id);
    }
}