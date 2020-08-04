using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForecastApi;

namespace ForecastApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RegionController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public RegionController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/Region
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
    {
      return await _context.Regions.ToListAsync();
    }

    // GET: api/Region/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Region>> GetRegion(long id)
    {
      var region = await _context.Regions.FindAsync(id);

      if (region == null)
      {
        return NotFound();
      }

      return region;
    }

    // PUT: api/Region/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRegion(long id, Region region)
    {
      if (id != region.Id)
      {
        return BadRequest();
      }

      _context.Entry(region).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RegionExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Region
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Region>> PostRegion(Region region)
    {
      _context.Regions.Add(region);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetRegion", new { id = region.Id }, region);
    }

    // DELETE: api/Region/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Region>> DeleteRegion(long id)
    {
      var region = await _context.Regions.FindAsync(id);
      if (region == null)
      {
        return NotFound();
      }

      _context.Regions.Remove(region);
      await _context.SaveChangesAsync();

      return region;
    }

    private bool RegionExists(long id)
    {
      return _context.Regions.Any(e => e.Id == id);
    }
  }
}
