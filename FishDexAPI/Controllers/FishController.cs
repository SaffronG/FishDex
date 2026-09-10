using Microsoft.AspNetCore.Mvc;
using FishDex.API.Data;
using FishDex.API.Models;

namespace FishDex.API.Controllers;

[ApiController]
[Route("api/[controller ]")]
public class FishController(List<string> _fish, FishDexContext db) : ControllerBase
{
    private readonly List<string> fish = _fish;
    private readonly FishDexContext _db = db;

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
    [HttpGet("fromdb")]
    public ActionResult<List<string>> FromDB([FromQuery] string? source = null)
    {
        var names = _db.Fish
            .AsQueryable()
            .Where(f => string.IsNullOrWhiteSpace(source) || f.Name.Contains(source, StringComparison.OrdinalIgnoreCase))
            .Select(f => f.Name)
            .ToList();

        return Ok(names);
    }
}