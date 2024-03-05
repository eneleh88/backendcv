using System.Text.Json;
using System.Text.Json.Serialization;
using CvApi.Data;
using CvApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CvApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    CvProjectContext _context;

    public ProfileController(CvProjectContext context)
    {
        _context = context;
    }

    // GET: api/Profile
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
    {
        var profiles = await _context.Profiles
            .Include(p => p.Certifications)
            .Include(p => p.Educations)
            .Include(p => p.Experiences)
            .Include(p => p.Socials)
            .Include(p => p.Strengths)
            .ToListAsync();

        if (profiles == null)
        {
            return NotFound();
        }

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        var json = JsonSerializer.Serialize(profiles, options);

        return Content(json, "application/json");
    }

    // GET: api/Profile/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Profile>> GetProfile(int id)
    {
        var profile = await _context.Profiles
            .Include(p => p.Certifications)
            .Include(p => p.Educations)
            .Include(p => p.Experiences)
            .Include(p => p.Socials)
            .Include(p => p.Strengths)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (profile == null)
        {
            return NotFound();
        }

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        var json = JsonSerializer.Serialize(profile, options);

        return Content(json, "application/json");
    }
}