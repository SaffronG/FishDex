using Microsoft.AspNetCore.Mvc;

namespace FishDex.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FishController() : ControllerBase
{
    private readonly List<string> fish = [];

    // GET /api/fish/test 
    [HttpGet("test")]
    public ActionResult<List<string>> TestAPI() => Accepted(new List<string> { "test1", "test2" });

    // GET /api/fish/byname?search=trout
    [HttpGet("byname")]
    public ActionResult<List<string>> GetAll([FromQuery] string? search)
    {
        var results = fish.AsEnumerable();

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
        if (index < 0 || index >= fish.Count) return NotFound();
        if (index is null ) return BadRequest();
        return Ok(fish[(int)index]);
    }

    // POST /api/fish  (body: a raw string, e.g. "Tiger Trout")
    [HttpPost]
    public ActionResult<string> Create([FromBody] string name)
    {
        fish.Add(name);
        var index = fish.Count - 1;
        return CreatedAtAction(nameof(GetByIndex), new { index }, name);
    }
}