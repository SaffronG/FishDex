using Microsoft.AspNetCore.Mvc;

namespace FishDex.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FishController : ControllerBase
{
    private readonly List<string> _fish;

    public FishController(List<string> fish)
    {
        _fish = fish;
    }

    // GET /api/fish/byname?search=trout
    [HttpGet("byname")]
    public ActionResult<List<string>> GetAll([FromQuery] string? search)
    {
        var results = _fish.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            results = results.Where(f => f.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        return Ok(results.ToList());
    }

    // GET /api/fish/byindex?index=2  
    // Fish is a real object with its own Id property)
    [HttpGet("byindex")]
    public ActionResult<string> GetByIndex([FromQuery] int? index)
    {
        if (index < 0 || index >= _fish.Count) return NotFound();
        if (index is null ) return BadRequest();
        return Ok(_fish[(int)index]);
    }

    // POST /api/fish  (body: a raw string, e.g. "Tiger Trout")
    [HttpPost]
    public ActionResult<string> Create([FromBody] string name)
    {
        _fish.Add(name);
        var index = _fish.Count - 1;
        return CreatedAtAction(nameof(GetByIndex), new { index }, name);
    }
}