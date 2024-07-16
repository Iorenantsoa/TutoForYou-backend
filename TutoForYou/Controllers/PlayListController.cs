using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TutoForYou.Data;

namespace TutoForYou.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public PlayListController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve // Use ReferenceHandler.Preserve to handle cycles
            };
        }

        [HttpGet("{formationId}")]
        public async Task<ActionResult<List<PlayList>>> Get(string formationId)
        {
            var playLists = await _appDbContext.PlayList
                .Where(f => f.FormationID == formationId).ToListAsync();

            var json = JsonSerializer.Serialize(playLists, _jsonSerializerOptions);

            return Content(json, "application/json");
        }

        [HttpGet("{formationId}/{numeroVideo}")]
        public async Task<ActionResult<PlayList>> Get(string formationId, int numeroVideo)
        {
            var playList = await _appDbContext.PlayList
                .Where(p => p.FormationID == formationId && p.NumeroVideo == numeroVideo)
                .FirstOrDefaultAsync();

            if (playList == null)
            {
                return NotFound();
            }

            var json = JsonSerializer.Serialize(playList, _jsonSerializerOptions);

            return Content(json, "application/json");
        }

    }
}
