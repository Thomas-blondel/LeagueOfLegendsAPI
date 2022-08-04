namespace LeagueOfLegends.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Scrapper.Model;
using Scrapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PatchNoteModel>))]
public class PatchNotesController: ControllerBase
{
    private readonly IPatchNotesScrapper _patchNotesScrapper;
    private readonly DatabaseContext _ctx;
    
    public PatchNotesController(IPatchNotesScrapper scrapper, DatabaseContext ctx)
    {
        _patchNotesScrapper = scrapper;
        _ctx = ctx;
    }

    /// <summary>Get the last 6 patch notes.</summary>
    /// <returns>Last 6 patch notes</returns>
    /// <response code="200">Returns the last 6 patch notes</response>
    [HttpGet(Name = "GetPatchNotes")]
    public async Task<IActionResult> Get()
    {
        var patchNotes = await _patchNotesScrapper.ParseRiotPageNotesPage();
        await _ctx.PatchNoteModels.AddRangeAsync(patchNotes);
        await _ctx.SaveChangesAsync();
        return Ok(patchNotes);
    }
    
    [HttpGet("GetAllPatchnotesFromDatabase")]
    public async Task<IActionResult> GetAll()
    {
        var patchNote = await _ctx.PatchNoteModels.ToListAsync();
        return Ok(patchNote);
    }
}