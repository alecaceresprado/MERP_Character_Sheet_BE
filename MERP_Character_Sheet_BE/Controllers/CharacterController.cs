using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MERP_Character_Sheet_BE.Models;


// TODO: USE DTO to avoid sending un necesary IDs 
namespace MERP_Character_Sheet_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/Character
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _characterService.GetAll();

            return Ok(result);
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public IActionResult GetCharacter(int id)
        {
            var result = _characterService.Get(id);

            return Ok(result);
        }

        // PUT: api/Character/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCharacter(long id, Character character)
        {
            return NoContent();
        }

        // POST: api/Character
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostCharacter(Character character)
        {
            var result = await _characterService.Create(character);

            return CreatedAtAction(
                nameof(GetCharacter),
                new { id = result.Id }, result);
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var result = await _characterService.Delete(id);

            return Ok(result);
        }
    }
}
