using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Services.SuperHeroServices;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            return await _superHeroService.GetAllHeros();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>>  GetSingleHero (int id)
        {
            var result = await _superHeroService.GetSingleHero(id);
            if (result is null)
            {
                return NotFound("There is no such id");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            return await _superHeroService.AddHero(hero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            if (result is null)
            {
                return NotFound("There is no such id");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result is null)
            {
                return NotFound("There is no such id");
            }
            return Ok(result);
        }
    }
} 
